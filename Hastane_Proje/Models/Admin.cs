using System.ComponentModel.DataAnnotations;

namespace Hastane_Proje.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [Display(Name = "Admin Kullanıcı Adı")]
        public string AdmiUserName { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [Display(Name = "Admin Şifre")]
        public string AdminPassword { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }

    }
}
