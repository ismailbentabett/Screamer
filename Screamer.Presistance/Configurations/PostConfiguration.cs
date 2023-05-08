/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Domain.Common;

namespace Screamer.Presistance.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration
    <
       Post
        >
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
        {
            builder.HasData
(
    new Post
    {
        Id = 1,
        Title = "First Post",
        Content = "First Post Description",
        UserId = 1,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now
    },
    new Post
    {
        Id = 2,
        Title = "Second Post",
        Content = "Second Post Description",
        UserId = 2,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now
    },
    new Post
    {
        Id = 3,
        Title = "Third Post",
        Content = "Third Post Description",
        UserId = 3,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now
    }
);
        }
    }
} */