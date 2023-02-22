using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
