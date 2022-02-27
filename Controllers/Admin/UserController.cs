using IPL_BALayer.Repo;
using IPL_DALayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPL_WEBApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGeneric<User> ser;
        public UserController(IGeneric<User> serr)
        {
            ser = serr;
        }
        [HttpGet("Show_User")]
        public IActionResult showUser()
        {
            try
            {
                return Ok(ser.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_User")]
        public IActionResult UpdateUser(User obj)
        {
            try
            {
                ser.Update(obj);
                return Ok("record updated..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add_User")]
        public IActionResult AddUser(User obj)
        {
            try
            {
                ser.add(obj);
                return Ok("record inserted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
