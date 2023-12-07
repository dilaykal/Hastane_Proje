using System.ComponentModel.DataAnnotations;

namespace Hastane_Proje.Models
{
    public class User
    {
        [Display(Name ="Kullanıcı Adı")]
        public string kullaniciAdi { get; set; }
        [Display(Name = "Şifre")]
        public string kullaniciSifre { get; set; } //
    }
}
