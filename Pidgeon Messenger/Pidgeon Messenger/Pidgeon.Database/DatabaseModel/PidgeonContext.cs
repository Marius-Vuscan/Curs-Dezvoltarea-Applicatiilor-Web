using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pidgeon.Data.DatabaseModel
{
    public partial class PidgeonContext : IdentityDbContext<IdentityUser>
    {
        public PidgeonContext()
        {
        }

        public PidgeonContext(DbContextOptions<PidgeonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<UsersGroup> UsersGroup { get; set; }
        public virtual DbSet<UserVsgroup> UserVsgroup { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
