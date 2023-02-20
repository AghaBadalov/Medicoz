﻿using Medicoz.DAL;
using Medicoz.Models;
using Medicoz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Controllers
{
    public class PlanController : Controller
    {
        private readonly AppDbContext _context;

        public PlanController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Plan> Plans = _context.Plans.Where(x => x.IsDeleted == false).Include(x => x.PlanCategory).ToList();
            return View(Plans);
        }
    }
}