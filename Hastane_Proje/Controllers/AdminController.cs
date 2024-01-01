using Hastane_Proje.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hastane_Proje.Controllers
{
    public class AdminController : Controller
    {
        private HastaneContext _context = new HastaneContext();

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(Admin p)
        {
            var adminuserinfo = _context.Admins.FirstOrDefault(x => x.AdmiUserName == p.AdmiUserName && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo != null)
            {
                //FormsAuthentication.SetAuthCookie(adminuserinfo.AdmiUserName,false);
                return RedirectToAction("PoliklinikDetay", "Poliklinik");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Admin()
        //{
        //    string[] roles = new string[2];
        //    roles[0] = "admin";
        //    roles[1] = "user";
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, "Dilay KAL"),
        //        new Claim(ClaimTypes.Role, "Dilay KAL"),
        //        new Claim(ClaimTypes.Name, "Dilay KAL"),
        //        new Claim(ClaimTypes.Name, "Dilay KAL"),

        //    };
        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var authProperties = new AuthenticationProperties();
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
