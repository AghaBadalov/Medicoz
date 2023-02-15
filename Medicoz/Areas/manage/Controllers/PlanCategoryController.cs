using Medicoz.DAL;
using Medicoz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Areas.manage.Controllers
{
    [Area("manage")]
    public class PlanCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public PlanCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<PlanCategory> categories = _context.PlanCategories.Where(x => x.IsDeleted == false).ToList();
            return View(categories);
        }
        public IActionResult Deletedcategories()
        {
            List<PlanCategory> categories = _context.PlanCategories.Where(x=>x.IsDeleted==true).ToList();
            return View(categories);

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PlanCategory category)
        {
            if (!ModelState.IsValid) return View();
            _context.PlanCategories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            PlanCategory category = _context.PlanCategories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(PlanCategory category)
        {
            PlanCategory exstcategory = _context.PlanCategories.FirstOrDefault(x => x.Id == category.Id);
            if (exstcategory == null) return NotFound();
            if (!ModelState.IsValid) return View(category);
            exstcategory.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            PlanCategory category = _context.PlanCategories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            _context.PlanCategories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Repair(int id)
        {
            PlanCategory category = _context.PlanCategories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            category.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult SoftDelete(int id)
        {
            PlanCategory category = _context.PlanCategories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            category.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
