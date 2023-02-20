using Medicoz.DAL;
using Medicoz.Helpers;
using Medicoz.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Areas.manage.Controllers
{
    [Area("manage")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Departments.AsQueryable();
            PaginatedList<Department> departments = PaginatedList<Department>.Create(query, 6, page);
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(!ModelState.IsValid) return View();
            _context.Departments.Add(department); 
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            Department department = _context.Departments.FirstOrDefault(x=>x.Id==id);
            if(department==null) return View("Error");
            return View(department);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            Department exstdepartment=_context.Departments.FirstOrDefault(x=>x.Id == department.Id);
            if(exstdepartment==null) return View("Error");
            if (!ModelState.IsValid) return View();
            exstdepartment.Name = department.Name;
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null) return View("Error");
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
