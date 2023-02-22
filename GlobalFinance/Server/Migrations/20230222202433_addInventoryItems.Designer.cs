﻿// <auto-generated />
using GlobalFinance.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20230222202433_addInventoryItems")]
    partial class addInventoryItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("GlobalFinance.Shared.Models.CarModel", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarMakeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CarModelName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CarOutrightStartingPrice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarStartingPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            CarMakeName = "Vauxhall",
                            CarModelName = "Corsa",
                            CarOutrightStartingPrice = 16995,
                            CarStartingPrice = 400
                        },
                        new
                        {
                            CarId = 2,
                            CarMakeName = "Vauxhall",
                            CarModelName = "Astra",
                            CarOutrightStartingPrice = 16995,
                            CarStartingPrice = 450
                        },
                        new
                        {
                            CarId = 3,
                            CarMakeName = "Vauxhall",
                            CarModelName = "Mokka",
                            CarOutrightStartingPrice = 21000,
                            CarStartingPrice = 450
                        },
                        new
                        {
                            CarId = 4,
                            CarMakeName = "Vauxhall",
                            CarModelName = "Grandland",
                            CarOutrightStartingPrice = 26000,
                            CarStartingPrice = 460
                        },
                        new
                        {
                            CarId = 5,
                            CarMakeName = "BMW",
                            CarModelName = "3-Series",
                            CarOutrightStartingPrice = 32000,
                            CarStartingPrice = 480
                        },
                        new
                        {
                            CarId = 6,
                            CarMakeName = "BMW",
                            CarModelName = "4-Series",
                            CarOutrightStartingPrice = 40000,
                            CarStartingPrice = 490
                        },
                        new
                        {
                            CarId = 7,
                            CarMakeName = "BMW",
                            CarModelName = "5-Series",
                            CarOutrightStartingPrice = 42000,
                            CarStartingPrice = 495
                        },
                        new
                        {
                            CarId = 8,
                            CarMakeName = "BMW",
                            CarModelName = "7-Series",
                            CarOutrightStartingPrice = 105000,
                            CarStartingPrice = 750
                        },
                        new
                        {
                            CarId = 9,
                            CarMakeName = "Audi",
                            CarModelName = "A1",
                            CarOutrightStartingPrice = 19000,
                            CarStartingPrice = 300
                        },
                        new
                        {
                            CarId = 10,
                            CarMakeName = "Audi",
                            CarModelName = "A3",
                            CarOutrightStartingPrice = 26000,
                            CarStartingPrice = 350
                        },
                        new
                        {
                            CarId = 11,
                            CarMakeName = "Audi",
                            CarModelName = "A4",
                            CarOutrightStartingPrice = 33000,
                            CarStartingPrice = 400
                        },
                        new
                        {
                            CarId = 12,
                            CarMakeName = "Audi",
                            CarModelName = "A5",
                            CarOutrightStartingPrice = 39000,
                            CarStartingPrice = 420
                        },
                        new
                        {
                            CarId = 13,
                            CarMakeName = "Audi",
                            CarModelName = "A6",
                            CarOutrightStartingPrice = 42000,
                            CarStartingPrice = 480
                        },
                        new
                        {
                            CarId = 14,
                            CarMakeName = "Audi",
                            CarModelName = "A7",
                            CarOutrightStartingPrice = 51000,
                            CarStartingPrice = 540
                        },
                        new
                        {
                            CarId = 15,
                            CarMakeName = "Audi",
                            CarModelName = "A8",
                            CarOutrightStartingPrice = 74000,
                            CarStartingPrice = 730
                        });
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.CustomerModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressFirstLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressPostcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressSecondLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressThirdLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.InventoryModel", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InventoryMileage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InventoryPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("InventoryId");

                    b.HasIndex("CarId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.ModelVariantModel", b =>
                {
                    b.Property<int>("ModelVariantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PriceIncrease")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModelVariantId");

                    b.HasIndex("CarId");

                    b.ToTable("ModelVariants");

                    b.HasData(
                        new
                        {
                            ModelVariantId = 1,
                            CarId = 1,
                            Name = "Design",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 2,
                            CarId = 1,
                            Name = "GS Line",
                            PriceIncrease = 2000
                        },
                        new
                        {
                            ModelVariantId = 3,
                            CarId = 1,
                            Name = "Ultimate",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 4,
                            CarId = 2,
                            Name = "Design",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 5,
                            CarId = 2,
                            Name = "GS Line",
                            PriceIncrease = 3000
                        },
                        new
                        {
                            ModelVariantId = 6,
                            CarId = 2,
                            Name = "Ultimate",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 7,
                            CarId = 3,
                            Name = "Design",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 8,
                            CarId = 3,
                            Name = "GS Line",
                            PriceIncrease = 3000
                        },
                        new
                        {
                            ModelVariantId = 9,
                            CarId = 3,
                            Name = "Ultimate",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 10,
                            CarId = 4,
                            Name = "Design",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 11,
                            CarId = 4,
                            Name = "GS Line",
                            PriceIncrease = 3000
                        },
                        new
                        {
                            ModelVariantId = 12,
                            CarId = 4,
                            Name = "Ultimate",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 13,
                            CarId = 5,
                            Name = "Sport",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 14,
                            CarId = 5,
                            Name = "M Sport",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 15,
                            CarId = 6,
                            Name = "Sport",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 16,
                            CarId = 6,
                            Name = "M Sport",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 17,
                            CarId = 7,
                            Name = "Sport",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 18,
                            CarId = 7,
                            Name = "M Sport",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 19,
                            CarId = 8,
                            Name = "Sport",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 20,
                            CarId = 8,
                            Name = "M Sport",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 21,
                            CarId = 9,
                            Name = "Technik",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 22,
                            CarId = 9,
                            Name = "Sport",
                            PriceIncrease = 4000
                        },
                        new
                        {
                            ModelVariantId = 23,
                            CarId = 9,
                            Name = "S Line",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 24,
                            CarId = 10,
                            Name = "Technik",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 25,
                            CarId = 10,
                            Name = "Sport",
                            PriceIncrease = 4000
                        },
                        new
                        {
                            ModelVariantId = 26,
                            CarId = 10,
                            Name = "S Line",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 27,
                            CarId = 11,
                            Name = "Technik",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 28,
                            CarId = 11,
                            Name = "Sport",
                            PriceIncrease = 4000
                        },
                        new
                        {
                            ModelVariantId = 29,
                            CarId = 11,
                            Name = "S Line",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 30,
                            CarId = 12,
                            Name = "Technik",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 31,
                            CarId = 12,
                            Name = "Sport",
                            PriceIncrease = 4000
                        },
                        new
                        {
                            ModelVariantId = 32,
                            CarId = 12,
                            Name = "S Line",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 33,
                            CarId = 13,
                            Name = "Technik",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 34,
                            CarId = 13,
                            Name = "Sport",
                            PriceIncrease = 4000
                        },
                        new
                        {
                            ModelVariantId = 35,
                            CarId = 13,
                            Name = "S Line",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 36,
                            CarId = 14,
                            Name = "Technik",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 37,
                            CarId = 14,
                            Name = "Sport",
                            PriceIncrease = 4000
                        },
                        new
                        {
                            ModelVariantId = 38,
                            CarId = 14,
                            Name = "S Line",
                            PriceIncrease = 6000
                        },
                        new
                        {
                            ModelVariantId = 39,
                            CarId = 15,
                            Name = "Technik",
                            PriceIncrease = 0
                        },
                        new
                        {
                            ModelVariantId = 40,
                            CarId = 15,
                            Name = "Sport",
                            PriceIncrease = 4000
                        },
                        new
                        {
                            ModelVariantId = 41,
                            CarId = 15,
                            Name = "S Line",
                            PriceIncrease = 6000
                        });
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.OfferModel", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OfferExpiry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OfferPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("OfferId");

                    b.HasIndex("CarId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            OfferId = 1,
                            CarId = 1,
                            OfferExpiry = "2/12/2002",
                            OfferPrice = 300
                        },
                        new
                        {
                            OfferId = 2,
                            CarId = 2,
                            OfferExpiry = "2/12/2002",
                            OfferPrice = 340
                        },
                        new
                        {
                            OfferId = 3,
                            CarId = 3,
                            OfferExpiry = "2/12/2002",
                            OfferPrice = 350
                        },
                        new
                        {
                            OfferId = 4,
                            CarId = 4,
                            OfferExpiry = "2/12/2002",
                            OfferPrice = 290
                        },
                        new
                        {
                            OfferId = 5,
                            CarId = 5,
                            OfferExpiry = "2/12/2002",
                            OfferPrice = 300
                        },
                        new
                        {
                            OfferId = 6,
                            CarId = 6,
                            OfferExpiry = "2/12/2002",
                            OfferPrice = 360
                        },
                        new
                        {
                            OfferId = 7,
                            CarId = 7,
                            OfferExpiry = "2/12/2002",
                            OfferPrice = 390
                        });
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.OrderModel", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.PaintModel", b =>
                {
                    b.Property<int>("PaintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PriceIncrease")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaintId");

                    b.HasIndex("CarId");

                    b.ToTable("PaintColours");

                    b.HasData(
                        new
                        {
                            PaintId = 1,
                            CarId = 1,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 2,
                            CarId = 1,
                            Name = "Crystal Silver",
                            PriceIncrease = 600
                        },
                        new
                        {
                            PaintId = 3,
                            CarId = 1,
                            Name = "Crimson Red",
                            PriceIncrease = 700
                        },
                        new
                        {
                            PaintId = 4,
                            CarId = 2,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 5,
                            CarId = 2,
                            Name = "Crystal Silver",
                            PriceIncrease = 600
                        },
                        new
                        {
                            PaintId = 6,
                            CarId = 2,
                            Name = "Cobalt Blue",
                            PriceIncrease = 600
                        },
                        new
                        {
                            PaintId = 7,
                            CarId = 3,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 8,
                            CarId = 3,
                            Name = "Voltaic Blue",
                            PriceIncrease = 600
                        },
                        new
                        {
                            PaintId = 9,
                            CarId = 3,
                            Name = "Iconic Green",
                            PriceIncrease = 700
                        },
                        new
                        {
                            PaintId = 10,
                            CarId = 4,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 11,
                            CarId = 4,
                            Name = "Contrast Grey",
                            PriceIncrease = 600
                        },
                        new
                        {
                            PaintId = 12,
                            CarId = 4,
                            Name = "Cobalt Blue",
                            PriceIncrease = 700
                        },
                        new
                        {
                            PaintId = 13,
                            CarId = 5,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 14,
                            CarId = 5,
                            Name = "Melbourne Red Metallic",
                            PriceIncrease = 695
                        },
                        new
                        {
                            PaintId = 15,
                            CarId = 5,
                            Name = "Black Sapphire Metallic",
                            PriceIncrease = 695
                        },
                        new
                        {
                            PaintId = 16,
                            CarId = 6,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 17,
                            CarId = 6,
                            Name = "Sunset Orange",
                            PriceIncrease = 695
                        },
                        new
                        {
                            PaintId = 18,
                            CarId = 6,
                            Name = "Black Sapphire Metallic",
                            PriceIncrease = 695
                        },
                        new
                        {
                            PaintId = 19,
                            CarId = 7,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 20,
                            CarId = 7,
                            Name = "Mineral White Metallic",
                            PriceIncrease = 900
                        },
                        new
                        {
                            PaintId = 21,
                            CarId = 7,
                            Name = "Black Sapphire Metallic",
                            PriceIncrease = 900
                        },
                        new
                        {
                            PaintId = 22,
                            CarId = 8,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 23,
                            CarId = 8,
                            Name = "Black Sapphire Metallic",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 24,
                            CarId = 8,
                            Name = "Oxide Grey",
                            PriceIncrease = 1100
                        },
                        new
                        {
                            PaintId = 25,
                            CarId = 9,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 26,
                            CarId = 9,
                            Name = "Python Yellow",
                            PriceIncrease = 575
                        },
                        new
                        {
                            PaintId = 27,
                            CarId = 9,
                            Name = "Mythos Black",
                            PriceIncrease = 575
                        },
                        new
                        {
                            PaintId = 28,
                            CarId = 10,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 29,
                            CarId = 10,
                            Name = "Forest Silver",
                            PriceIncrease = 575
                        },
                        new
                        {
                            PaintId = 30,
                            CarId = 10,
                            Name = "Mythos Black",
                            PriceIncrease = 575
                        },
                        new
                        {
                            PaintId = 31,
                            CarId = 11,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 32,
                            CarId = 11,
                            Name = "Forest Silver",
                            PriceIncrease = 675
                        },
                        new
                        {
                            PaintId = 33,
                            CarId = 11,
                            Name = "Navarra Blue",
                            PriceIncrease = 675
                        },
                        new
                        {
                            PaintId = 34,
                            CarId = 12,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 35,
                            CarId = 12,
                            Name = "Glacier White",
                            PriceIncrease = 675
                        },
                        new
                        {
                            PaintId = 36,
                            CarId = 12,
                            Name = "Tango Red",
                            PriceIncrease = 675
                        },
                        new
                        {
                            PaintId = 37,
                            CarId = 13,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 38,
                            CarId = 13,
                            Name = "Forest Silver",
                            PriceIncrease = 685
                        },
                        new
                        {
                            PaintId = 39,
                            CarId = 13,
                            Name = "Tango red",
                            PriceIncrease = 685
                        },
                        new
                        {
                            PaintId = 40,
                            CarId = 14,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 41,
                            CarId = 14,
                            Name = "Forest Grey",
                            PriceIncrease = 685
                        },
                        new
                        {
                            PaintId = 42,
                            CarId = 14,
                            Name = "Tango Red",
                            PriceIncrease = 685
                        },
                        new
                        {
                            PaintId = 43,
                            CarId = 15,
                            Name = "Solid White",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 44,
                            CarId = 15,
                            Name = "Firmament Blue",
                            PriceIncrease = 0
                        },
                        new
                        {
                            PaintId = 45,
                            CarId = 15,
                            Name = "Mythos Black",
                            PriceIncrease = 0
                        });
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.InventoryModel", b =>
                {
                    b.HasOne("GlobalFinance.Shared.Models.CarModel", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.ModelVariantModel", b =>
                {
                    b.HasOne("GlobalFinance.Shared.Models.CarModel", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.OfferModel", b =>
                {
                    b.HasOne("GlobalFinance.Shared.Models.CarModel", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.PaintModel", b =>
                {
                    b.HasOne("GlobalFinance.Shared.Models.CarModel", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("GlobalFinance.Shared.Models.UserModel", b =>
                {
                    b.HasOne("GlobalFinance.Shared.Models.CustomerModel", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
