using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asymmetric.Models;
using Asymmetric.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asymmetric.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Success");
        }
        [HttpGet("me")]
        [Authorize]
        public IActionResult Get()
        {
            return Content($"Hello {User.Identity.Name}");
        }

        [HttpPost("sign-in")]
        public IActionResult SignIn([FromBody]SignIn request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || request.Password != "secret")
            {
                return Unauthorized();
            }
            return  Ok(_jwtHandler.Create(request.Username));
        }
    }
}