using GlobalFinance.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GlobalFinance.Server.Data
{
    public class PublicDataContext : DbContext
    {
        public PublicDataContext(DbContextOptions<PublicDataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var parentDir = System.IO.Directory.GetCurrentDirectory();
            System.Diagnostics.Debug.WriteLine(parentDir);

            modelBuilder.Entity<CarModel>().HasData(
                JsonSerializer.Deserialize<List<CarModel>>(document: JsonDocument.Parse(File.ReadAllText(Path.Combine("Data", "Cars.json")))));

            modelBuilder.Entity<OfferModel>().HasData(
                JsonSerializer.Deserialize<List<OfferModel>>(document: JsonDocument.Parse(File.ReadAllText(Path.Combine("Data", "Offers.json")))));

            modelBuilder.Entity<ModelVariantModel>().HasData(
                JsonSerializer.Deserialize<List<ModelVariantModel>>(document: JsonDocument.Parse(File.ReadAllText(Path.Combine("Data", "ModelVariants.json")))));

            modelBuilder.Entity<PaintModel>().HasData(
                JsonSerializer.Deserialize<List<PaintModel>>(document: JsonDocument.Parse(File.ReadAllText(Path.Combine("Data", "PaintColours.json")))));

            modelBuilder.Entity<OrderModel>();
        }

        public DbSet<CarModel>? Cars { get; set; }
        public DbSet<OfferModel>? Offers { get; set; }
        public DbSet<ModelVariantModel>? ModelVariants { get; set; }
        public DbSet<PaintModel>? PaintColours { get; set; }
        public DbSet<OrderModel>? Orders { get; set; }
    }
}
