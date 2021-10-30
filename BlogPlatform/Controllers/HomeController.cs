using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Models;

namespace BlogPlatform.Controllers
{
    public class HomeController : Controller
    {
        private ContentContext _db;
        //private ContentContext db = new ContentContext();
        public HomeController(ContentContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }
        //[Route("Index/Content")]
        //[Produces("Title")]
        //[HttpGet("search")]
        //public IActionResult Search()
        //{
        //    try
        //    {
        //        string term = HttpContext.Request.Query["term"].ToString();
        //        var titles = db.Contents.Where(p => p.Title.Contains(term)).Select(p => p.Title).ToList();
        //        return Ok(titles);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
