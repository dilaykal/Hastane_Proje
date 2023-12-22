using System.ComponentModel.DataAnnotations;

namespace Hastane_Proje.Models
{
    public class Poliklinik
    {
        public int PoliklinikID { get; set; }
        public string PoliklinikAdi { get; set; }
        public string ?Aciklama { get; set; }
        public string ?TedaviAlani { get; set; }
        public ICollection<Doktor> ?Doktorlar { get; set; }

    }
}
