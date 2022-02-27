using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPL_DALayer;
using IPL_DALayer.Models;
using IPL_BALayer;
using IPL_BALayer.Repo;

namespace IPLWEBapi.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private IGeneric<Ticket> ViewTicket;

        public TicketsController(IGeneric<Ticket> ticket)
        {
            ViewTicket = ticket;
        }

        [HttpGet("View_Ticket_Information")]
        public IActionResult GetStudent()
        {
            try
            {
                return Ok(ViewTicket.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add_Ticket_Details")]
        public IActionResult AddTicketDetail(Ticket obj)
        {
            try
            {
                ViewTicket.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}