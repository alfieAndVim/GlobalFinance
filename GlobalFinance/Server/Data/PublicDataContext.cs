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
            modelBuilder.Entity<CarModel>().HasData(
                JsonSerializer.Deserialize<List<CarModel>>(document: JsonDocument.Parse(File.ReadAllText("Data\\Cars.json"))));

            modelBuilder.Entity<OfferModel>().HasData(
                JsonSerializer.Deserialize<List<OfferModel>>(document: JsonDocument.Parse(File.ReadAllText("Data\\Offers.json"))));

            //modelBuilder.Entity<CarModel>().HasData(
            //    new CarModel
            //    {
            //        CarId = 1,
            //        CarMakeName = "Vauxhall",
            //        CarModelName = "Corsa",
            //        CarStartingPrice = 300,
            //        CarOutrightStartingPrice = 12000
            //    }
            //    );

            //modelBuilder.Entity<OfferModel>().HasData(
            //    new OfferModel
            //    {
            //        OfferId = 1,
            //        OfferPrice = 250,
            //        OfferExpiry = "22/12/2002",
            //        CarId = 1
            //    }
            //);
        }

        public DbSet<CarModel>? Cars { get; set; }
        public DbSet<OfferModel>? Offers { get; set; }
    }
}
