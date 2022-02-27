using IPL_BALayer.Repo;
using IPL_DALayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPL_WEBapi.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private IGeneric<Team> t;

        public TeamsController(IGeneric<Team> team)
        {
            t = team;
        }

        [HttpPost("Add_Team")]
        public IActionResult AddTeam(Team obj)
        {
            try
            {
                t.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Team")]
        public IActionResult UpdateTeam(Team obj)
        {
            try
            {
                t.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_Team/{id}")]
        public IActionResult DeleteTeam(int id)
        {
            try
            {
                t.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_Team/{id}")]
        public IActionResult SearchTeam(int id)
        {
            try
            {
                return Ok(t.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListAll_Team")]
        public IActionResult ListAllTeam()
        {
            try
            {
                return Ok(t.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
