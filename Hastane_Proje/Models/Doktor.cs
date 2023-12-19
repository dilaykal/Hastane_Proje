using System.ComponentModel.DataAnnotations;

namespace Hastane_Proje.Models
{
    public class Doktor
    {
        public int DoktorID { get; set; }
        public string DoktorAdi{ get; set; }

        public DateTime DogumTarihi { get; set; }
        
        public string DogumYeri { get; set; }

        public string Mail { get; set; }
        public string Foto {  get; set; }

        public Poliklinik Poliklinik {  get; set; } 
 
    }
}
