﻿using Medicoz.DAL;
using Medicoz.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Areas.manage.Controllers
{
    [Area("manage")]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FeatureController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Feature> features=_context.Features.Where(x=>x.IsDeleted==false).ToList();
            return View(features);
        }
        public IActionResult DeletedFeature()
        {
            List<Feature> features = _context.Features.Where(x => x.IsDeleted == true).ToList();
            return View(features);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            if (!ModelState.IsValid) return View();
            _context.Features.Add(feature);
            feature.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if(feature == null) return View("error");
            return View(feature);
        }
        [HttpPost]
        public IActionResult Update(Feature feature)
        {
            Feature exstfeature = _context.Features.FirstOrDefault(x => x.Id == feature.Id);
            if(exstfeature is null) return View("error");
            exstfeature.Tittle= feature.Tittle;
            exstfeature.Desc= feature.Desc;
            exstfeature.Icon=feature.Icon;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult SoftDelete(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (feature == null) return View("error");
            feature.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Repair(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (feature == null) return View("error");
            feature.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction("deletedfeature");

        }
        public IActionResult Delete(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (feature == null) return View("error");
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return RedirectToAction("deletedfeature");
        }
    }
}
