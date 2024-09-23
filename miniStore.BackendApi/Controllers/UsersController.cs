﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniStore.Application.System.Users;
using miniStore.ViewModels.System.Users;
using System.Threading.Tasks;

namespace miniStore.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<LoginRequest> _validator;
        public UsersController(IUserService userService, IValidator<LoginRequest> validator) {
            _userService = userService;
            _validator = validator;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or password is incorrect.");
            }
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
           var result = await _userService.Register(request);
            if (!result) return BadRequest("Register is unsuccessful");
            return Ok();
        }
    }
}
