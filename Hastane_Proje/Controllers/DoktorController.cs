using Microsoft.AspNetCore.Mvc;

namespace Hastane_Proje.Controllers
{
    public class DoktorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DoktorEkle()
        {
            return View();
        }
    }
}
