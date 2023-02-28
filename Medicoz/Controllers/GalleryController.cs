using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
