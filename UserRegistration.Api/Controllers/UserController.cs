﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UserRegistration.Api.ViewModels;
using UserRegistration.Data.Entities;
using UserRegistration.Repository;
using UserRegistration.Service;

namespace UserRegistration.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;
        private readonly UserService userService;
        private readonly IMapper mapper;

        public UserController(UserRepository userRepository, UserService userService, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] UserViewModel userViewModel)
        {
            var user = mapper.Map<User>(userViewModel);

            if (userService.IsValid(user))
            {
                try
                {
                    userRepository.Add(user);
                    userRepository.SaveChanges();

                    return Created(string.Empty, user);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, (ex.Message, InnerException: ex.InnerException?.Message));
                }
            }

            return BadRequest(new { message = "Dados de usuário inválidos" });
        }

        [HttpGet("{subName}")]
        public ActionResult<List<UserViewModel>> Get(string subName)
        {
            var users = userRepository.GetMany(x => x.Name.ToLower().Contains(subName.ToLower()));

            if (users is null)
            {
                return Ok(new { message = "Nenhum usuário encontrado" });
            }

            try
            {
                return Ok(mapper.Map<List<UserViewModel>>(users));
            }
            catch (Exception ex)
            {
                return StatusCode(500, (ex.Message, InnerException: ex.InnerException?.Message));
            }
        }

        [HttpGet("GetByGender/{gender}")]
        public ActionResult<List<UserViewModel>> GetByGender(string gender)
        {
            var users = userRepository.GetMany(user => user.Gender.ToLower().Contains(gender.ToLower()));

            if (users is null)
            {
                return Ok(new { message = "Nenhum usuário encontrado" });
            }

            try
            {
                return Ok(mapper.Map<List<UserViewModel>>(users));
            }
            catch (Exception ex)
            {
                return StatusCode(500, (ex.Message, InnerException: ex.InnerException?.Message));
            }
        }
    }
}