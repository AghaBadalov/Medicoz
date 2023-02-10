using Medicoz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Medicoz.Controllers
{
    public class HomeController : Controller
    {
        

       

        public IActionResult Index()
        {
            return View();
        }

        
    }
}