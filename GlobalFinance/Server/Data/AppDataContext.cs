using GlobalFinance.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GlobalFinance.Server.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) {}

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

            

            modelBuilder.Entity<UserModel>();
            modelBuilder.Entity<CustomerModel>();
            modelBuilder.Entity<EnquiryModel>();
            modelBuilder.Entity<SavedConfigurationModel>();
            modelBuilder.Entity<FinanceModel>();
            modelBuilder.Entity<FinanceDocumentModel>();
            modelBuilder.Entity<CustomisationModel>()
                .HasData(
                new CustomisationModel { CustomisationId = 1, ModelVariantId = 1, PaintId = 1, CarId = 1 },
                new CustomisationModel { CustomisationId = 2, ModelVariantId = 1, PaintId = 1, CarId = 2 }
                );
            modelBuilder.Entity<InventoryModel>().HasData(

                new InventoryModel { InventoryId = 1, InventoryPrice = 12000, InventoryMileage = 12000, CustomisationId = 1 },
                new InventoryModel { InventoryId = 2, InventoryPrice = 12000, InventoryMileage = 12000, CustomisationId = 2 }
                );

            modelBuilder.Entity<CustomisationModel>()
                .HasOne(C => C.ModelVariant)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<CustomisationModel>()
                .HasOne(C => C.Paint)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);
        }

        public DbSet<CarModel>? Cars { get; set; }
        public DbSet<OfferModel>? Offers { get; set; }
        public DbSet<ModelVariantModel>? ModelVariants { get; set; }
        public DbSet<PaintModel>? PaintColours { get; set; }
        public DbSet<UserModel>? Users { get; set; }
        public DbSet<CustomerModel>? Customers { get; set; }
        public DbSet<EnquiryModel>? Orders { get; set; }
        public DbSet<SavedConfigurationModel>? SavedConfigurations { get; set; }
        public DbSet<FinanceModel>? Finances { get; set; }
        public DbSet<FinanceDocumentModel>? FinanceDocuments { get; set; }
        public DbSet<CustomisationModel> Customisations { get; set; }
        public DbSet<InventoryModel>? Inventory { get; set; }
    }
}
