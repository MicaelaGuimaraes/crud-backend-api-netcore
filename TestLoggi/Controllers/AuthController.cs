using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TestLoggi.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserService UserService;

        public AuthController(UserService _UserService)
        {
            UserService = _UserService;
        }

        //Post
        [HttpPost]
        public IActionResult Auth([FromBody] Login user)
        {
            if (user == null)
            {
                return BadRequest("No data was informed, please review the data sent.");
            }
            else
            {
                var data = UserService.GetByEmail(user.Email);

                if (data != null)
                {
                    var token = TokenService.GenerateToken(data);
                    return Ok(new { Token = token });
                }
                else
                {
                    return Unauthorized();
                }

            }
        }
    }
}

