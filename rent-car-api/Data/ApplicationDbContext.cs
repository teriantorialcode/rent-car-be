using Microsoft.EntityFrameworkCore;
using rent_car_api.Models;

namespace rent_car_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Atur schema untuk masing-masing tabel
            modelBuilder.Entity<Car>().ToTable("Cars", "product");
            modelBuilder.Entity<Booking>().ToTable("Bookings", "transaction");

            base.OnModelCreating(modelBuilder);
        }
    }
}
