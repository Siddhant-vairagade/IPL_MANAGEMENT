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
    public class TeamAndPlayerController : ControllerBase
    {
        private IGeneric<Team> t;
        private IGeneric<Player> p;

        public TeamAndPlayerController(IGeneric<Team> team, IGeneric<Player> player)
        {
            t = team;
            p = player;
        }

        [HttpGet("View Team Information")]
        public IActionResult List_Team()
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
        [HttpGet("View Player Information")]
        public IActionResult List_Player()
        {
            try
            {
                return Ok(p.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
