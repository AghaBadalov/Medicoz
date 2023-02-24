using Medicoz.DAL;
using Medicoz.Models;
using Medicoz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Medicoz.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
       

        public IActionResult Index()
        {
            HomeVM vm = new HomeVM
            {
                Sliders=_context.Sliders.Where(x=>x.IsDeleted==false).ToList(),
                Plans=_context.Plans.Where(x=>x.IsDeleted==false).Include(x=>x.PlanCategory).ToList(),
            };
            return View(vm);
        }

        
    }
}