using Hastane_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hastane_Proje.Controllers
{
    public class RandevuController : Controller
    {
        private HastaneContext _context = new HastaneContext();

        public IActionResult Randevu(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hasta = _context.Kullanıcılar.FirstOrDefault(x => x.UserID == id);
            if (hasta == null) return NotFound();

            return View(hasta);
        }
    }
}
