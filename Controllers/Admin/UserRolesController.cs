using IPL_BALayer.Repo;
using IPL_DALayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPL_WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {

        private IGeneric<UserRole> ur;
        public UserRolesController(IGeneric<UserRole> urole)
        {
            ur = urole;
        }
        [HttpGet("Show_UserRole")]
        public IActionResult showUserRole()
        {
            try
            {
                return Ok(ur.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_UserRole")]
        public IActionResult UpdateUserRole(UserRole obj)
        {
            try
            {
                ur.Update(obj);
                return Ok("record updated..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add_UserRole")]
        public IActionResult AddUserRole(UserRole obj)
        {
            try
            {
                ur.add(obj);
                return Ok("record inserted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
