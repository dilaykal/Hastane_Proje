using Hastane_Proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hastane_Proje.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIN(User usr)
        {
            return View();
        }
    }
}
