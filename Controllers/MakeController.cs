using BikeShop.Data;
using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class MakeController : Controller
    {
        private readonly BikeShopDbContext _db;

        public MakeController(BikeShopDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {

            return View(_db.makes.ToList());
        }

        //Get method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Add(make);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(make);
        }

        public IActionResult Edit()
        {
            return View();
        }

        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {

            var make = _db.makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }
            _db.makes.Remove(make);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var make = _db.makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Update(make);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(make);
        }

    }
}
