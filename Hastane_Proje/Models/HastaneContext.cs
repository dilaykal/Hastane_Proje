using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Hastane_Proje.Models
{
    public class HastaneContext : DbContext
    {
        public DbSet<Doktor> Doktorlar { get; set; }  //Kitap isimli sınıfım Kitaplar isimli bir tabloya karşılık gelsin
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<User> Kullanıcılar { get; set; }
        
        public DbSet<Admin> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
        Database=Hastane; Trusted_Connection=True;");    //dependency enjection ilee nasıl tanımlanır???
        }     //Trusted_Connection windows ile bağlan
    }
}
