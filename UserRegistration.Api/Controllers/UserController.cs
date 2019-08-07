using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using UserRegistration.Api.ViewModels;
using UserRegistration.Domain.Entities;
using UserRegistration.Repository;

namespace UserRegistration.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(UserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<UserViewModel> Post([FromBody] UserViewModel userViewModel)
        {
            var user = mapper.Map<User>(userViewModel);

            if (user.Valid)
            {
                try
                {
                    userRepository.Add(user);
                    return Created(string.Empty, userViewModel);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, (ex.Message, InnerException: ex.InnerException?.Message));
                }
            }

            return BadRequest(user);
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