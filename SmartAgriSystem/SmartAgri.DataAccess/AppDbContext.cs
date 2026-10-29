using Microsoft.EntityFrameworkCore;
using SmartAgri.Entities;

namespace SmartAgri.DataAccess
{
    public class AppDbContext : DbContext
    {
        // Veritabanındaki Tablolarımız
        public DbSet<User> Users { get; set; }
        public DbSet<Greenhouse> Greenhouses { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<SensorLog> SensorLogs { get; set; }

        public AppDbContext()
        {
            // Dosya veya tablolar eksikse otomatik oluşturur
            Database.EnsureCreated();
        }

        // SQLite Veritabanı Dosya Yolu Bağlantısı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı dosyasının uygulamanın çalıştığı klasörde tam yol ile aranmasını sağlıyoruz
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "smartagri.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}