namespace Hastane_Proje.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }
        public DateTime randevuTarihi { get; set; }

        public User hasta { get; set; }

        public Doktor doktor { get; set; }
    }
}
