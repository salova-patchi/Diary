using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry
                {
                    Id = 1,
                    Title = "Graduation Day",
                    Description = "I had an amazing day at my graduation party.",
                    Created = new DateTime(2025, 1, 15, 10, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Id = 2,
                    Title = "First Job Interview",
                    Description = "I was nervous but I think it went well!",
                    Created = new DateTime(2025, 1, 25, 14, 30, 0),
                    Mood = Mood.Anxious
                },
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Vacation Time",
                    Description = "Spent a relaxing week at the beach with friends.",
                    Created = new DateTime(2025, 2, 10, 9, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Id = 4,
                    Title = "Started Learning C#",
                    Description = "Excited to start building apps with C# and ASP.NET Core.",
                    Created = new DateTime(2025, 2, 20, 11, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Id = 5,
                    Title = "First Coding Project",
                    Description = "Completed my first small console app today!",
                    Created = new DateTime(2025, 3, 1, 16, 0, 0),
                    Mood = Mood.Grateful
                },
                new DiaryEntry
                {
                    Id = 6,
                    Title = "Rainy Day",
                    Description = "It rained all day, stayed indoors and read a book.",
                    Created = new DateTime(2025, 3, 5, 13, 30, 0),
                    Mood = Mood.Calm
                },
                new DiaryEntry
                {
                    Id = 7,
                    Title = "Gym Motivation",
                    Description = "Had an amazing workout, feeling strong and healthy.",
                    Created = new DateTime(2025, 3, 10, 18, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Id = 8,
                    Title = "Coffee with Friend",
                    Description = "Met an old friend for coffee, great conversation.",
                    Created = new DateTime(2025, 3, 15, 15, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Id = 9,
                    Title = "Learning Guitar",
                    Description = "Practiced guitar for 2 hours, learning a new song.",
                    Created = new DateTime(2025, 3, 20, 17, 0, 0),
                    Mood = Mood.Calm
                },
                new DiaryEntry
                {
                    Id = 10,
                    Title = "Movie Night",
                    Description = "Watched a classic movie and enjoyed every minute.",
                    Created = new DateTime(2025, 3, 25, 20, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Id = 11,
                    Title = "Hiking Trip",
                    Description = "Went hiking in the mountains, breathtaking views.",
                    Created = new DateTime(2025, 3, 30, 8, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Id = 12,
                    Title = "Cooking Experiment",
                    Description = "Tried a new recipe today, turned out delicious.",
                    Created = new DateTime(2025, 4, 5, 12, 0, 0),
                    Mood = Mood.Grateful
                },
                new DiaryEntry
                {
                    Id = 13,
                    Title = "Volunteer Work",
                    Description = "Helped at a local shelter, felt very fulfilling.",
                    Created = new DateTime(2025, 4, 10, 9, 30, 0),
                    Mood = Mood.Grateful
                },
                new DiaryEntry
                {
                    Id = 14,
                    Title = "Coding Challenge",
                    Description = "Solved a tricky coding problem, very proud!",
                    Created = new DateTime(2025, 4, 15, 14, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Id = 15,
                    Title = "Relaxing Sunday",
                    Description = "Spent the day relaxing, reading, and enjoying music.",
                    Created = new DateTime(2025, 4, 20, 10, 0, 0),
                    Mood = Mood.Calm
                }
            );
        }
    }
}
