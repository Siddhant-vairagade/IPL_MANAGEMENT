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
    public class VenuesController : ControllerBase
    {
        private IGeneric<Venue> v;

        public VenuesController(IGeneric<Venue> ven)
        {
            v = ven;
        }

        [HttpPost("Add_Venue")]
        public IActionResult AddVenue(Venue obj)
        {
            try
            {
                v.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Venue")]
        public IActionResult UpdateVenue(Venue obj)
        {
            try
            {
                v.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_Venue/{id}")]
        public IActionResult DeleteVenue(int id)
        {
            try
            {
                v.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_Venue/{id}")]
        public IActionResult SearchVenue(int id)
        {
            try
            {
                return Ok(v.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListAll_Venues")]
        public IActionResult ListAllVenue()
        {
            try
            {
                return Ok(v.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
