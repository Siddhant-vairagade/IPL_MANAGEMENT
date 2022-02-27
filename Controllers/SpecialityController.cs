using IPL_BALayer.Repo;
using IPL_DALayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IPL_WEBapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
         private IGeneric<Specialty> specialty;

        public SpecialtyController(IGeneric<Specialty> S)
        {
            specialty = S;
        }

        [HttpPost("Add_Specialty")]
        public IActionResult InsertSpecialty(Specialty obj)
        {
            try
            {
                specialty.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_Specialty")]
        public IActionResult UpdateSpecialty(Specialty obj)
        {
            try
            {
                specialty.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete_Specialty/{id}")]
        public IActionResult DeleteSpecialty(int id)
        {
            try
            {
                specialty.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("Search_Speciality/{id}")]
        public IActionResult ShowSpecialtyById(int id)
        {
            try
            {
                return Ok(specialty.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






        [HttpGet("ShowAll_Specialty")]
        public IActionResult ShowAllSpecialty()
        {
            try
            {
                return Ok(specialty.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}