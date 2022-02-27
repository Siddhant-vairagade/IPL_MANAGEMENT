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
    public class SpecialityController : ControllerBase
    {
        private IGeneric<Specialty> s;

        public SpecialityController(IGeneric<Specialty> spe)
        {
            s = spe;
        }

        [HttpPost("Add_Speciality")]
        public IActionResult AddSpeciality(Specialty obj)
        {
            try
            {
                s.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Speciality")]
        public IActionResult UpdateSpeciality(Specialty obj)
        {
            try
            {
                s.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_Speciality/{id}")]
        public IActionResult DeleteSpeciality(int id)
        {
            try
            {
                s.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_Speciality/{id}")]
        public IActionResult SearchSpeciality(int id)
        {
            try
            {
                return Ok(s.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListAll_Speciality")]
        public IActionResult ListAllSpeciality()
        {
            try
            {
                return Ok(s.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
