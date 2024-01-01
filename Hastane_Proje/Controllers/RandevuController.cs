using Hastane_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        public class RandevuModel
        {
            public string SelectedDate { get; set; }
            public string SelectedHour { get; set; }
            public int DoktorID { get; set; } // Yeni eklenen özellik
                                              // Diğer gerekli alanları ekleyebilirsiniz
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

       
        [HttpPost]
        public IActionResult RandevuKaydet([FromBody] RandevuModel model)
        {
            // Kullanıcı bilgilerini Cookie'ye sakla (Bu kısmı önceki cevapta anlatılmıştır)

            // Doktor bilgilerini al
            int doktorID = model.DoktorID;
            Doktor doktor = _context.Doktorlar.FirstOrDefault(d => d.DoktorID == doktorID);

            // Seçilen tarih ve saat bilgilerini birleştir
            DateTime randevuTarihi = CombineDateTime(model.SelectedDate, model.SelectedHour);

            // Veritabanına kaydetmek üzere yeni bir Randevu nesnesi oluştur
            Randevu randevu = new Randevu
            {
                randevuTarihi = randevuTarihi,
                doktor = doktor,  // Doktor bilgisini ekleyin
                hasta = _context.Kullanıcılar.FirstOrDefault(k => k.UserID == 1)            // Diğer gerekli alanları doldur
            };

            // Veritabanına kaydet
            _context.Add(randevu);
            _context.SaveChanges();

            // Başarılı bir yanıt gönder
            return Ok(new { success = true });
        }
        private DateTime CombineDateTime(string selectedDate, string selectedHour)
        {
            // Seçilen tarih ve saat bilgilerini ayrı ayrı parse edin
            DateTime date = DateTime.Parse(selectedDate);
            DateTime time = DateTime.ParseExact(selectedHour, "HH:mm", CultureInfo.InvariantCulture);

            // Tarih ve saati birleştirerek yeni bir DateTime nesnesi oluşturun
            DateTime combinedDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);

            return combinedDateTime;
        }
    }
}
