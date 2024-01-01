using Hastane_Proje.Models;
using Microsoft.AspNetCore.Mvc;

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
            //sreturn View();
        }
    }
}
