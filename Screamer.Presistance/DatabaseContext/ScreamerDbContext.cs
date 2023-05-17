using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Domain.Entities;
using Screamer.Domain.Common;
using Screamer.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Screamer.Identity.Models;

namespace Screamer.Presistance.DatabaseContext
{
    public class ScreamerDbContext : IdentityDbContext<ApplicationUser>
    {
        public ScreamerDbContext(DbContextOptions<ScreamerDbContext> options) : base(options)
        {
        }


        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }

        public DbSet<Follow> Follows { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(
                ScreamerDbContext
            ).Assembly);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Message>()
                            .HasOne(u => u.Recipient)
                            .WithMany(m => m.MessagesReceived)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Follow>()
                            .HasKey(k => new { k.SourceUserId, k.TargetUserId });

            modelBuilder.Entity<Follow>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.Following)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Follow>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.Followers)
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.Cascade);

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