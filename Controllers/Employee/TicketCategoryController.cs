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
    public class TicketsController : ControllerBase
    {

        private IGeneric<Ticket> t;

        public TicketsController(IGeneric<Ticket> tick)
        {
            t = tick;
        }

        [HttpPost("Add_Ticket")]
        public IActionResult AddTicket(Ticket obj)
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

        [HttpPut("Update_Ticket")]
        public IActionResult UpdateTicket(Ticket obj)
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

        [HttpDelete("Delete_Ticket/{id}")]
        public IActionResult DeleteTicket(int id)
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

        [HttpGet("Search_Ticket/{id}")]
        public IActionResult SearchTicket(int id)
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

        [HttpGet("ListAll_Ticket")]
        public IActionResult ListAllTicket()
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
