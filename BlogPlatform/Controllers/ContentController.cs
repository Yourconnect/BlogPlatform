using BlogPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Controllers
{
    public class ContentController : Controller
    {
        private ContentContext _db;
        public ContentController(ContentContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Contents.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories.ToList(), "Id", "Name");
            return View(new Content());
        }
        [HttpPost]
        public IActionResult Create(Content Contents)
        {
            _db.Contents.Add(Contents);
            _db.SaveChanges();

            //retun view();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var content = _db.Contents.Find(id);
            _db.Contents.Remove(content);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var content = _db.Contents.Find(id);
            content.PublishDate = DateTime.Now;

            return View(content);
        }

        [HttpPost]
        public IActionResult Edit(Content model)
        {
            _db.Update(model);
            //_db.SaveChanges();

            //retun view();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var content = _db.Contents.Find(id);
            return View(content);
        }
    }
}
