using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Revifast.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=revifast.database.windows.net;Database=DbRevifastFASGugz;User Id=admin1;Password=Pierofernando1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.Id).HasColumnName("UsuarioId");

            builder.Entity<IdentityUserRole<string>>().ToTable("RolUsuario");
            builder.Entity<IdentityUserLogin<string>>().ToTable("LoginUsuario");
            builder.Entity<IdentityUserClaim<string>>().ToTable("ClaimUsuario");
            builder.Entity<IdentityUserToken<string>>().ToTable("TokenUsuario");

            builder.Entity<IdentityRole>().ToTable("Rol");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RolClaim");
        }
    }
}