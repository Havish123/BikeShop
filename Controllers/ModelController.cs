using BikeShop.Data;
using BikeShop.Models;
using BikeShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Controllers
{
    public class ModelController : Controller
    {
        private readonly BikeShopDbContext _db;

        [BindProperty]
        public BikeViewModel Model_dt { get; set; }

        public ModelController(BikeShopDbContext db)
        {
            _db = db;
            Model_dt = new BikeViewModel()
            {
                Makes = _db.makes.ToList(),
                Model = new Models.Model()
            };
        }

        public IActionResult Index()
        {
            var model = _db.models.Include(m => m.Make);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(Model_dt);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(BikeViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(Model_dt);
            }
            _db.Add(Model_dt.Model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Model_dt.Model = _db.models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
            if (Model_dt.Model == null)
            {
                return NotFound();
            }
            return View(Model_dt);
        }


        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (ModelState.IsValid)
            {
                return View(Model_dt);
            }
            _db.Update(Model_dt.Model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Model model = _db.models.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _db.models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
