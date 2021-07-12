using Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService UserService;

        public UserController(UserService _UserService)
        {
            UserService = _UserService;
        }

        //Get
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<Entity.User>> GetUser()
        {
            return await UserService.GetAllUser();
        }

        //Get/{id}
        [Route("{id}")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Entity.User>> GetUser(int? id)
        {
            if (id == null)
                return BadRequest("Please, provide an Id");
            else
            {
                return await UserService.GetByIdUser(id);
            }
        }

        //Post
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Entity.User>> PostUser([FromBody] Entity.User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Check the data sent.");
            }
            else
            {
                try
                {
                    data.CreateDate = DateTime.Now;
                    var datas = await UserService.PostUser(data);
                    return Ok(datas);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        //Put
        [Route("{id}")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Entity.User>> PutUser(int id, [FromBody] Entity.User User)
        {
            if (id != User.Id)
            {
                return BadRequest("The given id is not the same as the json id.");
            }
            else
            {
                try
                {
                    var datas = await UserService.PutUser(User);
                    return Ok(datas);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        //Delete
        [Route("{id}")]
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Entity.User>> DeleteUser(int? id)
        {
            if (id == null)
                return BadRequest("Please, provide an Id");
            else
            {
                try
                {
                    var data = await UserService.DeleteUser(id);
                    return Ok(data);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }
    }
}
