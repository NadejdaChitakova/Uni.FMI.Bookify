﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uni.FMI.Bookify.Infrastructure.Data;

#nullable disable

namespace Uni.FMI.Bookify.Infrastructure.Data.Migrations
{
    [DbContext(typeof(IdentityCoreDbContext))]
    [Migration("20240804122637_AddNumberOfGuestsInApartments")]
    partial class AddNumberOfGuestsInApartments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("IdentityUserLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.Amenity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Amenity");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApartmentAmenity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AmenityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AmenityId");

                    b.HasIndex("ApartmentId");

                    b.ToTable("ApartmentAmenity");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AmenitiesUpCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ApartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CancelledOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CleaningFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CompletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ConfirmedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PriceForPeriod")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("RejectedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Apartment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CleaningFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("LastBookedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<string>("OwnewId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OwnewId");

                    b.ToTable("Apartment");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.ApartmentImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMainPhoto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("ApartmentImage");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDisabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUsers", (string)null);
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApartmentAmenity", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.Amenity", "Amenity")
                        .WithMany("ApartmentAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Apartment", "Apartment")
                        .WithMany("Amenities")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationRole", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationUserRole", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.Booking", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Apartment", "Apartment")
                        .WithMany("Bookings")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.ApplicationUser", "ApplicationUser")
                        .WithMany("Bookings")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Uni.FMI.Bookify.Infrastructure.Models.Common.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateOnly>("End")
                                .HasColumnType("date");

                            b1.Property<DateOnly>("Start")
                                .HasColumnType("date");

                            b1.HasKey("BookingId");

                            b1.ToTable("Booking");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.Navigation("Apartment");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Duration")
                        .IsRequired();
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.City", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Address", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Apartment", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Address", "Address")
                        .WithOne("Apartment")
                        .HasForeignKey("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Apartment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.ApplicationUser", "Owner")
                        .WithMany("Apartments")
                        .HasForeignKey("OwnewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.ApartmentImage", b =>
                {
                    b.HasOne("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Apartment", "Apartment")
                        .WithMany("ApartmentImages")
                        .HasForeignKey("ApartmentId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.Amenity", b =>
                {
                    b.Navigation("ApartmentAmenities");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.ApplicationRole", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Infrastructure.Models.DbEntities.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Address", b =>
                {
                    b.Navigation("Apartment")
                        .IsRequired();
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Apartment", b =>
                {
                    b.Navigation("Amenities");

                    b.Navigation("ApartmentImages");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.ApplicationUser", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("Bookings");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
