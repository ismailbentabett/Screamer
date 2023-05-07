using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Domain.Entities;
using Screamer.Domain.Common;
using Screamer.Domain;
namespace Screamer.Presistance.DatabaseContext
{
    public class ScreamerDbContext : DbContext
    {
        public ScreamerDbContext(DbContextOptions<ScreamerDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Post> Posts { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(
                ScreamerDbContext
            ).Assembly);
            base.OnModelCreating(modelBuilder);


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                  
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

}
    }