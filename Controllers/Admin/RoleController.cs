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
    public class RoleController : ControllerBase
    {

        private IGeneric<Role> r;
        public RoleController(IGeneric<Role> role)
        {
            r = role;
        }
        [HttpGet("Show_Role")]
        public IActionResult showRole()
        {
            try
            {
                return Ok(r.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Role")]
        public IActionResult UpdateRole(Role obj)
        {
            try
            {
                r.Update(obj);
                return Ok("record updated..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add_Role")]
        public IActionResult AddRole(Role obj)
        {
            try
            {
                r.add(obj);
                return Ok("record inserted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
