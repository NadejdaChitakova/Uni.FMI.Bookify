using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal sealed class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasKey(applicationRole => applicationRole.Id);

            builder.Property(applicationRole => applicationRole.Description)
                .HasMaxLength(2000);

            builder.HasMany(applicationRole => applicationRole.UserRoles)
                .WithOne(applicationRole => applicationRole.Role)
                .HasForeignKey(applicationRole => applicationRole.RoleId);

            builder.HasMany(applicationRole => applicationRole.Claims)
                .WithOne(applicationRole => applicationRole.Role)
                .HasForeignKey(applicationRole => applicationRole.RoleId);
        }
    }
}
