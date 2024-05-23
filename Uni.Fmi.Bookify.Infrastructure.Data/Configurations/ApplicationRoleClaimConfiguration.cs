using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal class ApplicationRoleClaimConfiguration :IEntityTypeConfiguration<ApplicationRoleClaim> 
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.HasKey(roleClaim => roleClaim.Id);

            builder.HasOne(roleClaim => roleClaim.Role)
                .WithMany(roleClaim => roleClaim.Claims)
                .HasForeignKey(role => role.RoleId);
        }
    }
}
