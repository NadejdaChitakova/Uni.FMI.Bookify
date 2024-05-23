using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
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

                countries.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulgaria"
                });

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

                context.Add(applicationUserRole);

                context.SaveChanges();
            }
        }
    }
}
