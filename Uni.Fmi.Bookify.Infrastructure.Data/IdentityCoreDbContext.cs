using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;


namespace Uni.FMI.Bookify.Infrastructure.Data
{
    public class IdentityCoreDbContext 
        :   IdentityDbContext<ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole,
        IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
    { 
        private readonly IConfiguration _configuration;
        public IdentityCoreDbContext() { }

        public IdentityCoreDbContext(DbContextOptions<IdentityCoreDbContext> options, IConfiguration configuration) :
            base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IdentityCoreDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString =
            //    _configuration.GetConnectionString("Database") ??
            //    throw new ArgumentNullException(nameof(_configuration));

            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=bookify; user id=sa; password=Na!12345678;  TrustServerCertificate=True;");
        }
    }
}
