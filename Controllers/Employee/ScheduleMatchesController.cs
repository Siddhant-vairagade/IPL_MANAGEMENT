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
    public class ScheduleMatchesController : ControllerBase
    {
        private IGeneric<Schedule> sm;

        public ScheduleMatchesController(IGeneric<Schedule> scmatch)
        {
            sm = scmatch;
        }

        [HttpPost("Add_ScheduleMatch")]
        public IActionResult AddScehduleMatch(Schedule obj)
        {
            try
            {
                sm.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_ScehduleMatch")]
        public IActionResult UpdateScheduleMatch(Schedule obj)
        {
            try
            {
                sm.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_ScheduleMatch/{id}")]
        public IActionResult DeleteScheduleMatch(int id)
        {
            try
            {
                sm.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_ScheduleMatch/{id}")]
        public IActionResult SearchScheduleMatch(int id)
        {
            try
            {
                return Ok(sm.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListAll_ScheduleMatches")]
        public IActionResult ListAllScheduleMatches()
        {
            try
            {
                return Ok(sm.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
