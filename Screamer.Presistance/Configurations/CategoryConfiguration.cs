using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Screamer.Domain.Entities;

namespace Screamer.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            // ... Other property and relationship configurations

            // Configure data seeding
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "News" },
                new Category { Id = 2, Name = "Politics" },
                new Category { Id = 3, Name = "Science" },
                new Category { Id = 4, Name = "Technology" },
                new Category { Id = 5, Name = "Gaming" },
                new Category { Id = 6, Name = "Sports" },
                new Category { Id = 7, Name = "Music" },
                new Category { Id = 8, Name = "Movies" },
                new Category { Id = 9, Name = "Television" },
                new Category { Id = 10, Name = "Books" },
                new Category { Id = 11, Name = "Art" },
                new Category { Id = 12, Name = "Food" },
                new Category { Id = 13, Name = "Travel" },
                new Category { Id = 14, Name = "Fitness" },
                new Category { Id = 15, Name = "Health" },
                new Category { Id = 16, Name = "Fashion" },
                new Category { Id = 17, Name = "Relationships" },
                new Category { Id = 18, Name = "Advice" },
                new Category { Id = 19, Name = "Writing" },
                new Category { Id = 20, Name = "Photography" },
                new Category { Id = 21, Name = "DIY (Do-It-Yourself)" },
                new Category { Id = 22, Name = "Nature" },
                new Category { Id = 23, Name = "Animals" },
                new Category { Id = 24, Name = "Memes" },
                new Category { Id = 25, Name = "Funny" },
                new Category { Id = 26, Name = "Jokes" },
                new Category { Id = 27, Name = "History" },
                new Category { Id = 28, Name = "Philosophy" },
                new Category { Id = 29, Name = "Psychology" },
                new Category { Id = 30, Name = "Education" },
                new Category { Id = 31, Name = "Career" },
                new Category { Id = 32, Name = "Personal Finance" },
                new Category { Id = 33, Name = "Entrepreneurship" },
                new Category { Id = 34, Name = "Parenting" },
                new Category { Id = 35, Name = "Relationships" },
                new Category { Id = 36, Name = "Technology News" },
                new Category { Id = 37, Name = "Programming" },
                new Category { Id = 38, Name = "Web Development" },
                new Category { Id = 39, Name = "Data Science" },
                new Category { Id = 40, Name = "Cryptocurrency" },
                new Category { Id = 41, Name = "Design" },
                new Category { Id = 42, Name = "Gaming News" },
                new Category { Id = 43, Name = "PC Gaming" },
                new Category { Id = 44, Name = "Console Gaming" },
                new Category { Id = 45, Name = "Mobile Gaming" },
                new Category { Id = 46, Name = "Esports" },
                new Category { Id = 47, Name = "Music News" },
                new Category { Id = 48, Name = "Hip-Hop" },
                new Category { Id = 49, Name = "Rock" },
                new Category { Id = 50, Name = "Pop Culture" },
                new Category { Id = 51, Name = "Fitness Motivation" },
                new Category { Id = 52, Name = "Nutrition" },
                new Category { Id = 53, Name = "Weightlifting" },
                new Category { Id = 54, Name = "Yoga" },
                new Category { Id = 55, Name = "Running" },
                new Category { Id = 56, Name = "Cycling" },
                new Category { Id = 57, Name = "CrossFit" },
                new Category { Id = 58, Name = "Bodybuilding" },
                new Category { Id = 59, Name = "Productivity" },
                new Category { Id = 60, Name = "Self-improvement" },
                new Category { Id = 61, Name = "Meditation" },
                new Category { Id = 62, Name = "Mindfulness" },
                new Category { Id = 63, Name = "Motivation" },
                new Category { Id = 64, Name = "Self-care" },
                new Category { Id = 65, Name = "Cooking" },
                new Category { Id = 66, Name = "Baking" },
                new Category { Id = 67, Name = "Grilling" },
                new Category { Id = 68, Name = "Veganism" },
                new Category { Id = 69, Name = "Vegetarianism" },
                new Category { Id = 70, Name = "Meal Prep" },
                new Category { Id = 71, Name = "Gardening" },
                new Category { Id = 72, Name = "Home Improvement" },
                new Category { Id = 73, Name = "Interior Design" },
                new Category { Id = 74, Name = "Real Estate" },
                new Category { Id = 75, Name = "Personal Finance Tips" },
                new Category { Id = 76, Name = "Investing" },
                new Category { Id = 77, Name = "Stock Market" },
                new Category { Id = 78, Name = "Cryptocurrency Trading" },
                new Category { Id = 79, Name = "Entrepreneur Stories" },
                new Category { Id = 80, Name = "Startups" },
                new Category { Id = 81, Name = "Small Business" },
                new Category { Id = 82, Name = "Marketing" },
                new Category { Id = 83, Name = "Social Media" },
                new Category { Id = 84, Name = "Podcasts" },
                new Category { Id = 85, Name = "Writing Prompts" },
                new Category { Id = 86, Name = "Fantasy" },
                new Category { Id = 87, Name = "Science Fiction" },
                new Category { Id = 88, Name = "Horror" },
                new Category { Id = 89, Name = "Thrillers" },
                new Category { Id = 90, Name = "True Crime" },
                new Category { Id = 91, Name = "Paranormal" },
                new Category { Id = 92, Name = "Comics" },
                new Category { Id = 93, Name = "Anime" },
                new Category { Id = 94, Name = "Manga" },
                new Category { Id = 95, Name = "Board Games" },
                new Category { Id = 96, Name = "Card Games" },
                new Category { Id = 97, Name = "Tabletop RPGs" },
                new Category { Id = 98, Name = "Travel Photography" },
                new Category { Id = 99, Name = "Outdoor Adventures" },
                new Category { Id = 100, Name = "Celebrities" }
            };

            builder.HasData(categories);
        }
    }
}
