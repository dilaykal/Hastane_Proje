using Hastane_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hastane_Proje.Controllers
{
    public class DoktorController : Controller
    {
        private HastaneContext _c = new HastaneContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DoktorEkle()
        {
            return View();
        }
        public IActionResult DoktorDetay(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doktor = _c.Doktorlar.Include(p=>p.Poliklinik).FirstOrDefault(x=>x.DoktorID == id);
            if (doktor == null) return NotFound();

            return View(doktor);
        }
    }
}
