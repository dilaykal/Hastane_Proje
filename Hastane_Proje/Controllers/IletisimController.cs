using Microsoft.AspNetCore.Mvc;

namespace Hastane_Proje.Controllers
{
    public class IletisimController : Controller
    {
        public IActionResult IletisimForm()
        {
            return View();
        }
    }
}
