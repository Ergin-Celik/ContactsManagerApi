using Business.Interfaces;
using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController: Controller
    {
        private IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Get a user with its person(al) information.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UserGetDto> GetUser(Guid id)
        {
            return Ok(_userManager.GetUser(id));
        }

        /// <summary>
        /// Add a user and his person(al) information.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<UserGetDto> Register(UserAddDto user)
        {
            return Ok(_userManager.AddUser(user));
        }

        /// <summary>
        /// Authenticate to the api and get a jwt bearer token.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<TokenGetDto> Authenticate(UserAuthenticationGetDto dto)
        {
            TokenGetDto token = _userManager.Authenticate(dto);

            return Ok(token);
        }
    }
}
