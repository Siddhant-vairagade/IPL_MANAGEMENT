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
    public class ViewNewsController : ControllerBase
    {
        private IGeneric<News> n;
  
        public ViewNewsController(IGeneric<News> ne)
        {
            n = ne;
        }

        [HttpGet("View News Information")]
        public IActionResult List_News()
        {
            try
            {
                return Ok(n.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
