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
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostHashtag> PostHashtags { get; set; }

        public ICollection<PostUserMention> PostUserMentions { get; set; } 
        public ICollection<PostUserTag> PostUserTags { get; set; } 

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
                .Entity<PostReaction>()
                .HasOne(r => r.Post)
                .WithMany(p => p.Reactions)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<CommentReaction>()
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
            modelBuilder.Entity<PostHashtag>().HasKey(bc => new { bc.PostId, bc.HashtagId });

            modelBuilder
                .Entity<PostCategory>()
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostCategories)
                .HasForeignKey(bc => bc.PostId);
            modelBuilder
                .Entity<PostHashtag>()
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostHashtags)
                .HasForeignKey(bc => bc.PostId);
            modelBuilder
                .Entity<PostCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(bc => bc.CategoryId);
            modelBuilder
                .Entity<PostHashtag>()
                .HasOne(bc => bc.Hashtag)
                .WithMany(c => c.PostHashtags)
                .HasForeignKey(bc => bc.HashtagId);

            modelBuilder.Entity<Post>().Property(p => p.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder
                .Entity<Message>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Post>().Property(p => p.UpdatedAt).HasDefaultValueSql("getdate()");
            modelBuilder
                .Entity<Message>()
                .Property(p => p.UpdatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder
                .Entity<Post>()
                .HasOne(p => p.Mood)
                .WithMany(m => m.Posts)
                .HasForeignKey(p => p.MoodId)
                .OnDelete(DeleteBehavior.Restrict);

            /* mentions and taggings */
            modelBuilder.Entity<PostUserMention>().HasKey(bc => new { bc.PostId, bc.UserId});
            modelBuilder.Entity<PostUserTag>().HasKey(bc => new { bc.PostId, bc.UserId });

            modelBuilder
                .Entity<PostUserMention>()
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostUserMentions)
                .HasForeignKey(bc => bc.PostId);
            modelBuilder
                .Entity<PostUserTag>()
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostUserTags)
                .HasForeignKey(bc => bc.PostId);
            modelBuilder
                .Entity<PostUserMention>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.PostUserMentions)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder
                .Entity<PostUserTag>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.PostUserTags)
                .HasForeignKey(bc => bc.UserId);
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
