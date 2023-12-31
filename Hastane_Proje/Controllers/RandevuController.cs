using Hastane_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hastane_Proje.Controllers
{
    public class RandevuController : Controller
    {
        private HastaneContext _context = new HastaneContext();

      /*  public IActionResult Randevu(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hasta = _context.Kullanıcılar.FirstOrDefault(x => x.UserID == id);
            if (hasta == null) return NotFound();

            return View(hasta);
        }*/
        public IActionResult Randevu() {
            return View(_context);
        }
        public IActionResult DoktorSecimi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var birim = _context.Poliklinikler.Include(d => d.Doktorlar).FirstOrDefault(x => x.PoliklinikID == id);
            if (birim == null) return NotFound();

            return View(birim);
           
        }
        public IActionResult TarihSecimi(int id) {

            if (id == null)
            {
                return NotFound();
            }
            var birim = _context.Doktorlar.Include(r=> r.randevular).FirstOrDefault(x => x.DoktorID == id);
            if (birim == null) return NotFound();

            return View(birim);
        }
        public IActionResult Index()
        {
            return View();
        }

        public void RandevuKaydet()
        {

        }
    }
}
