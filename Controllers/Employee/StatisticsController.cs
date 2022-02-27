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
    public class StatisticsController : ControllerBase
    {
        private IGeneric<Statistic> st;

        public StatisticsController(IGeneric<Statistic> stat)
        {
            st = stat;
        }

        [HttpPost("Add_Statistic")]
        public IActionResult AddStatistic(Statistic obj)
        {
            try
            {
                st.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Statistic")]
        public IActionResult UpdateStatistic(Statistic obj)
        {
            try
            {
                st.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_Statistic/{id}")]
        public IActionResult DeleteStatistic(int id)
        {
            try
            {
                st.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_Statistics/{id}")]
        public IActionResult SearchStatistic(int id)
        {
            try
            {
                return Ok(st.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListAll_Statistics")]
        public IActionResult ListAllStatistics()
        {
            try
            {
                return Ok(st.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
