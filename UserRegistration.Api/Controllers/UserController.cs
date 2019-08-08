﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Get(int id)
        {
            try
            {
                return Ok(mapper.Map<UserViewModel>(userRepository.GetById(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, (ex.Message, InnerException: ex.InnerException?.Message));
            }
        }
    }
}