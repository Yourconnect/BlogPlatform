using BlogPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Controllers
{
    public class CategoryController : Controller
    {
        private ContentContext _db;
        public CategoryController(ContentContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }
        public IActionResult Create()
        {
            return View(_db.Contents.ToList());
        }
        [HttpPost]
        public IActionResult Create(Category Categories)
        {
            _db.Categories.Add(Categories);
            _db.SaveChanges();

            //retun view();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var category = _db.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            _db.Update(model);
            _db.SaveChanges();

            //retun view();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }
    }
}
