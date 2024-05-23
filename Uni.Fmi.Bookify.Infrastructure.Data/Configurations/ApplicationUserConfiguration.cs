using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("IdentityUsers");

            builder.HasKey(x => x.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(50);

            builder.Property(user => user.LastName)
                .HasMaxLength(50);

            builder.Property(user => user.IsDisabled)
                .HasDefaultValue(true);

            builder.HasMany(user => user.UserRoles)
                .WithOne(user => user.User)
                .HasForeignKey(user => user.UserId);

            builder.HasMany(user => user.Apartments)
                .WithOne(user => user.Owner)
                .HasForeignKey(user => user.OwnewId);

            builder.HasMany(user => user.Bookings)
                .WithOne(user => user.ApplicationUser)
                .HasForeignKey(user => user.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
