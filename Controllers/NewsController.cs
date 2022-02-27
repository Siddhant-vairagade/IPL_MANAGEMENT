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
    public class NewsController : ControllerBase
    {
        private IGeneric<News> news;
        public NewsController(IGeneric<News> N)
        {
            news = N;
        }

        [HttpPost("Add_News")]
        public IActionResult InsertNews(News obj)
        {
            try
            {
                news.add(obj);
                return Ok("Record Added ..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update_News")]
        public IActionResult UpdateNews(News obj)
        {
            try
            {
                news.Update(obj);
                return Ok("Record Updated ....");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("Delete_News/{id}")]
        public IActionResult DeleteNews(int id)
        {
            try
            {
                news.Delete(id);
                return Ok("record deleted..");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Search_News/{id}")]
        public IActionResult ShowNewsById(int id)
        {
            try
            {
                return Ok(news.search(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ShowAll_News")]
        public IActionResult ShowAllNews()
        {
            try
            {
                return Ok(news.list());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}