using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pidgeon.Data.DatabaseModel
{
    public partial class PidgeonContext : IdentityDbContext<StoreUser>
    {
        public PidgeonContext()
        {
        }

        public PidgeonContext(DbContextOptions<PidgeonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__UserGrou__737584F6168E0EFD")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
