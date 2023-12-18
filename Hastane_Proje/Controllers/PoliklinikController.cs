using Microsoft.AspNetCore.Mvc;

namespace Hastane_Proje.Controllers
{
    public class PoliklinikController : Controller
    {
        public IActionResult Birimler()
        {
            return View();
        }
    }
}
