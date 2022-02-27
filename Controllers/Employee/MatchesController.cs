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
    public class MatchesController : ControllerBase
    {
        private IGeneric<Match> m;

        public MatchesController(IGeneric<Match> Matches)
        {
            m = Matches;
        }

        [HttpPost("Add_Match")]
        public IActionResult AddMatch(Match obj)
        {
            try
            {
                m.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Match")]
        public IActionResult UpdateMatch(Match obj)
        {
            try
            {
                m.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_Match/{id}")]
        public IActionResult DeleteMatch(int id)
        {
            try
            {
                m.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_Match/{id}")]
        public IActionResult SearchMatch(int id)
        {
            try
            {
                return Ok(m.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListAll_Matches")]
        public IActionResult ListAllMatches()
        {
            try
            {
                return Ok(m.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
