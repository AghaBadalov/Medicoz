using Medicoz.DAL;
using Medicoz.Helpers;
using Medicoz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Medicoz.Areas.manage.Controllers
{
    [Area("manage")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<About> abouts = _context.Abouts.ToList();
            
            return View(abouts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(About about)
        {
            if (_context.Abouts.Count() > 0) return NotFound();
            if (!ModelState.IsValid) return View();
            if(about.MiddleImage is null)
            {
                ModelState.AddModelError("MiddleImage", "Can't be null");
                return View(about);
            }
            if (about.BigImage is null)
            {
                ModelState.AddModelError("BigImage", "Can't be null");
                return View(about);
            }
            if (about.SmallImage is null)
            {
                ModelState.AddModelError("SmallImage", "Can't be null");
                return View(about);
            }
            //middle
            if (about.MiddleImage.Length > 2097152)
            {
                ModelState.AddModelError("MiddleImage", "Image size must be 2mb or lower");
                return View();
            }
            if (about.MiddleImage.ContentType != "image/png" && about.MiddleImage.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("MiddleImage", "Image type must be png, jpg or jpeg");
                return View();
            }
            about.MiddleImageUrl = about.MiddleImage.SaveFile("uploads/abouts", _env.WebRootPath);
            //Small
            if (about.SmallImage.Length > 2097152)
            {
                ModelState.AddModelError("SmallImage", "Image size must be 2mb or lower");
                return View();
            }
            if (about.SmallImage.ContentType != "image/png" && about.SmallImage.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("SmallImage", "Image type must be png, jpg or jpeg");
                return View();
            }
            about.SmallImageUrl = about.SmallImage.SaveFile("uploads/abouts", _env.WebRootPath);
            //Big
            if (about.BigImage.Length > 2097152)
            {
                ModelState.AddModelError("BigImage", "Image size must be 2mb or lower");
                return View();
            }
            if (about.BigImage.ContentType != "image/png" && about.BigImage.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("BigImage", "Image type must be png, jpg or jpeg");
                return View();
            }
            about.BigImageUrl = about.BigImage.SaveFile("uploads/abouts", _env.WebRootPath);
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Update(int id)
        {
            About about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if(about == null) return View("error");
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(About about)
        {
            About exstabout=_context.Abouts.FirstOrDefault(x=>x.Id == about.Id);
            if (exstabout == null) return View("error");
            if (!ModelState.IsValid) return View(about);
            if(about.MiddleImage != null)
            {
                if (about.MiddleImage.Length > 2097152)
                {
                    ModelState.AddModelError("MiddleImage", "Image size must be 2mb or lower");
                    return View(about);
                }
                if (about.MiddleImage.ContentType != "image/png" && about.MiddleImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("MiddleImage", "Image type must be png, jpg or jpeg");
                    return View(about);
                }

            }
        }
    }
}
