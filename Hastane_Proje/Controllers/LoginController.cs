using Hastane_Proje.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hastane_Proje.Controllers
{
    public class LoginController : Controller
    {
        private HastaneContext _context = new HastaneContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIN(User usr)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            string[] roles = new string[2];
            roles[0] = "admin";
            roles[1] = "user";
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "ahmet yılmaz"),
                new Claim(ClaimTypes.Role, "admin"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return RedirectToAction("Index", "Home");
        }
    }
}
