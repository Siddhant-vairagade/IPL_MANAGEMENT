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
    public class PlayersController : ControllerBase
    {
        private IGeneric<Player> p;

        public PlayersController(IGeneric<Player> Player)
        {
            p = Player;
        }

        [HttpPost("Add_Player")]
        public IActionResult AddPlayer(Player obj)
        {
            try
            {
                p.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Player")]
        public IActionResult UpdatePlayer(Player obj)
        {
            try
            {
                p.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_Player/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            try
            {
                p.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_Player/{id}")]
        public IActionResult SearchPlayer(int id)
        {
            try
            {
                return Ok(p.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListAll_Players")]
        public IActionResult ListAllPlayer()
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
