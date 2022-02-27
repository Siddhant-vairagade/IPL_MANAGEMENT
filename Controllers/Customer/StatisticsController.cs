using IPL_BALayer.Repo;
using IPL_DALayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPL_WEBapi.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewStatisticsController : ControllerBase
    {
        private IGeneric<Statistic> ViewStatistic;



        public ViewStatisticsController(IGeneric<Statistic> statistics)
        {
            ViewStatistic = statistics;
        }



        [HttpGet("View Statistic Information")]
        public IActionResult GetStatistic()
        {
            try
            {
                return Ok(ViewStatistic.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}