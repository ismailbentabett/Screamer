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
        public ScreamerDbContext(DbContextOptions<ScreamerDbContext> options)
            : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }

        public DbSet<Follow> Follows { get; set; }
        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScreamerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>().HasKey(k => new { k.SourceUserId, k.TargetUserId });

            modelBuilder
                .Entity<Follow>()
                .HasOne(u => u.SourceUser)
                .WithMany(m => m.Following)
                .HasForeignKey(f => f.SourceUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Follow>()
                .HasOne(u => u.TargetUser)
                .WithMany(m => m.Followers)
                .HasForeignKey(f => f.TargetUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Reaction>()
                .HasOne(r => r.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Reaction>()
                .HasOne(r => r.Comment)
                .WithMany(c => c.Reactions)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChatRoomUser>().HasKey(cu => new { cu.ChatroomId, cu.UserId });

            modelBuilder
                .Entity<ChatRoomUser>()
                .HasOne(cu => cu.ChatRoom)
                .WithMany(c => c.ChatRoomUsers)
                .HasForeignKey(cu => cu.ChatroomId);

            modelBuilder
                .Entity<ChatRoomUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.ChatRoomUsers)
                .HasForeignKey(cu => cu.UserId);

            modelBuilder.Entity<PostCategory>().HasKey(bc => new { bc.PostId, bc.CategoryId });
            modelBuilder
                .Entity<PostCategory>()
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostCategories)
                .HasForeignKey(bc => bc.PostId);
            modelBuilder
                .Entity<PostCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(bc => bc.CategoryId);    

                
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (
                var entry in base.ChangeTracker
                    .Entries<BaseEntity>()
                    .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified)
            )
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
