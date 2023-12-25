using System.ComponentModel.DataAnnotations;

namespace Hastane_Proje.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Bu alanı doldurmak zorunludur")]
        [Display(Name ="Kullanıcı Adı")]
        public string kullaniciAdi { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [Display(Name = "Şifre")]
        public string kullaniciSifre { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [Display(Name = "İsim")]
        public string isim { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [Display(Name = "Soyisim")]
        public string soyisim { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [EmailAddress(ErrorMessage ="Geçerli bir mail adres giriniz.")]
        [Display(Name = "E-posta")]
        public string eposta { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [Display(Name = "Telefon Numarası")]
        public string telNo { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [Display(Name = "TC Kimlik Numarası")]
        public string tcNo { get; set; }
        [Display(Name = "Adres")]
        public string adres { get; set; }
        public ICollection<Randevu>? randevular { get; set; }



    }
}
