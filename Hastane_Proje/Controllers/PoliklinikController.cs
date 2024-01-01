using Hastane_Proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hastane_Proje.Controllers
{
    public class PoliklinikController : Controller
    {
        private HastaneContext _context = new HastaneContext();
        public IActionResult Birimler()
        {
            return View();
        }

        public IActionResult PoliklinikDetay(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var birim = _context.Poliklinikler.Include(d=>d.Doktorlar).FirstOrDefault(x=>x.PoliklinikID == id);
            if(birim == null) return NotFound();

            return View(birim);
        }

    }
}
