using Microsoft.EntityFrameworkCore;
using LocadoraDeCarrosAPI.Models;

namespace LocadoraDeCarrosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("CARS");
                entity.HasKey(c => c.CarId);
                entity.Property(c => c.CarId).HasColumnName("CAR_ID").ValueGeneratedOnAdd();
                entity.Property(c => c.Model).HasColumnName("MODEL").HasMaxLength(100).IsRequired();
                entity.Property(c => c.Brand).HasColumnName("BRAND").HasMaxLength(100).IsRequired();
                entity.Property(c => c.Year).HasColumnName("YEAR").IsRequired();
                entity.Property(c => c.DailyRate).HasColumnName("DAILY_RATE").HasPrecision(10,2).IsRequired();
            });

           
            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("RENTALS");
                entity.HasKey(r => r.RentalId);
                entity.Property(r => r.RentalId).HasColumnName("RENTAL_ID").ValueGeneratedOnAdd();
                entity.Property(r => r.CarId).HasColumnName("CAR_ID").IsRequired();
                entity.Property(r => r.StartDate).HasColumnName("START_DATE").IsRequired();
                entity.Property(r => r.EndDate).HasColumnName("END_DATE").IsRequired();
                entity.HasOne(r => r.Car).WithMany().HasForeignKey(r => r.CarId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}


