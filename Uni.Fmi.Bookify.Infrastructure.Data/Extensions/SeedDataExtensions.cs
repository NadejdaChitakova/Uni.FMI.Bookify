using Microsoft.AspNetCore.Builder;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.Common;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.SeedDataExtensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var context = new IdentityCoreDbContext())
            {
                List<Country> countries = [];

                Country bulgaria = new Country()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulgaria"
                };
                countries.Add(bulgaria);

                countries.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Italy"
                });

                countries.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Spanish"
                });

                countries.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = "London"
                });

                countries.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Turkey"
                });

                context.Set<Country>().AddRange(countries);

                ApplicationRole adminRole = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = "Admin",
                    Name = "Admin"
                };

                ApplicationRole userRole = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = "User",
                    Name = "User"
                };

                context.Set<ApplicationRole>().Add(adminRole);
                context.Set<ApplicationRole>().Add(userRole);

                context.SaveChanges();

                ApplicationUser admin = new()
                {
                    UserName = "admin@admin.bg",
                    NormalizedUserName = "ADMIN@ADMIN.BG",
                    Email = "admin@admin.bg",
                    NormalizedEmail = "ADMIN@ADMIN.BG",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    FirstName = "FirstName",
                    LastName = "LastName",
                    IsDisabled = false,
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEL0MUQRBwzPSEdFUwNfjZG6DtdIPgzT3GFTq3om3qyvgNtaiMaq7MOIjuzIZAeBOqA==",
                    SecurityStamp = "GR2SGM4HELJ75C4BOKESZMMV44UDW4WY",
                    ConcurrencyStamp = "635a95ff-6c5a-4f11-9e7b-427c77a0d5e1",
                };

                context.Set<ApplicationUser>().Add(admin);

                context.SaveChanges();

                ApplicationUserRole applicationUserRole = new()
                {
                    UserId = admin.Id,
                    RoleId = userRole.Id,
                    CreatorName = "Nadezhda Chitakova",
                    TimeCreated = DateTime.UtcNow
                };

                var amenities = InitializeAmenities();
                context.Set<Amenity>().AddRange(amenities);

                Apartment apartment = new()
                {
                    Id = Guid.NewGuid(),
                    OwnewId = admin.Id,
                    Name = "The green apartment",
                    CleaningFee = 10,
                    Price =150,
                    Currency = Currency.BGN,
                    Description = "The best apartment",
                    
                    Address = new Address()
                    {
                        Id = new Guid(),
                        City = "Plovdiv",
                        Street = "bul.Bulgaria 105",
                        CountryId = bulgaria.Id,
                    }
                };

                context.Add(applicationUserRole);

                context.Set<Apartment>()
                    .Add(apartment);

                context.SaveChanges();

                ApartmentAmenity apartmentAmenity = new()
                {
Id = Guid.NewGuid(),
AmenityId = amenities.FirstOrDefault().Id,
ApartmentId = apartment.Id
                };

                context.Set<ApartmentAmenity>().Add(apartmentAmenity);
                context.SaveChanges();
            }
        }

        private static List<Amenity> InitializeAmenities()
        {
            List<Amenity> amenities =
            [
                new Amenity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Air condition",
                    Price = 5,
                },
                new Amenity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Wifi",
                    Price = 2,
                },
                new Amenity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Parking",
                    Price = 5,
                },
                new Amenity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pet friendly",
                    Price = 15,
                },
                new Amenity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Swimming pool",
                    Price = 15,
                },
                new Amenity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gum",
                    Price = 5,
                },
                new Amenity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Spa",
                    Price = 5,
                },
                new Amenity()
                {
                    Id = new Guid(),
                    Name = "Terrace",
                    Price = 2,
                },
                new Amenity()
                {
                Id = Guid.NewGuid(),
                Name = "MountainView",
                Price = 3
                }
            ];

            return amenities;
        }
    }
}
