using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal class IdentityUserLoginConfigurations : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.ToTable("IdentityUserLogin");
        }
    }
}
