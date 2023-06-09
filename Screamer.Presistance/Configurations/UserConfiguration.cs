using Screamer.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin",
                     NormalizedUserName = "ADMIN",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user",
                     NormalizedUserName = "USER",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 },
                    new ApplicationUser
                    {
                        Id = "9e224968-33e4-4652-b7b7-agfddsr",
                        Email = "mod@localhost.com",
                        NormalizedEmail = "MOD@LOCALHOST.COM",
                        FirstName = "System",
                        LastName = "Mod",
                        UserName = "mod",
                        NormalizedUserName = "MOD",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "9e224968-33e4-4652-b7b7-ismailbentabett",
                        Email = "ismailbentabett@gmail.com",
                        NormalizedEmail = "ISMAILBENTABETT@GMAIL.COM",
                        FirstName = "Ismail",
                        LastName = "Bentabet",
                        UserName = "ismailbentabett",
                        NormalizedUserName = "ISMAILBENTABETT",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = false
                    }
            );
        }
    }
}