using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Services
{
    public class DatabaseCleanupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DatabaseCleanupService> _logger;
        private readonly IConfiguration _configuration;
        private TimeSpan _cleanupInterval;
        private bool _enabled;

        public DatabaseCleanupService(
            IServiceProvider serviceProvider,
            ILogger<DatabaseCleanupService> logger,
            IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _configuration = configuration;

            // Read settings from configuration
            _enabled = _configuration.GetValue<bool>("DatabaseCleanup:Enabled", true);
            var intervalHours = _configuration.GetValue<int>("DatabaseCleanup:IntervalHours", 2);
            _cleanupInterval = TimeSpan.FromHours(intervalHours);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!_enabled)
            {
                _logger.LogInformation("⏸️ Database Cleanup Service is disabled in configuration");
                return;
            }

            _logger.LogInformation("🔄 Database Cleanup Service started - Cleanup every {Hours} hours", _cleanupInterval.TotalHours);

            // Wait before first cleanup
            await Task.Delay(_cleanupInterval, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CleanupAndReseedDatabase();
                    _logger.LogInformation("⏰ Next cleanup scheduled in {Hours} hours at {Time}",
                        _cleanupInterval.TotalHours,
                        DateTime.Now.Add(_cleanupInterval).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Error occurred during database cleanup");
                }

                await Task.Delay(_cleanupInterval, stoppingToken);
            }
        }



        private async Task CleanupAndReseedDatabase()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                try
                {
                    _logger.LogInformation("🧹 Starting database cleanup at {Time}...", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    // Delete all diary entries
                    var allEntries = await context.DiaryEntries.ToListAsync();
                    var count = allEntries.Count;

                    context.DiaryEntries.RemoveRange(allEntries);
                    await context.SaveChangesAsync();

                    _logger.LogInformation("🗑️ Deleted {Count} diary entries", count);

                    // Re-seed with your existing seed data
                    var seedData = GetSeedData();
                    await context.DiaryEntries.AddRangeAsync(seedData);
                    await context.SaveChangesAsync();

                    _logger.LogInformation("✅ Re-seeded database with {Count} entries", seedData.Count);
                    _logger.LogInformation("✨ Database cleanup completed successfully!");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Failed to cleanup database");
                    throw;
                }
            }
        }

        // Your existing seed data
        private List<DiaryEntry> GetSeedData()
        {
            return new List<DiaryEntry>
            {
                new DiaryEntry
                {
                    Title = "Graduation Day",
                    Description = "I had an amazing day at my graduation party.",
                    Created = new DateTime(2025, 1, 15, 10, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Title = "First Job Interview",
                    Description = "I was nervous but I think it went well!",
                    Created = new DateTime(2025, 1, 25, 14, 30, 0),
                    Mood = Mood.Anxious
                },
                new DiaryEntry
                {
                    Title = "Vacation Time",
                    Description = "Spent a relaxing week at the beach with friends.",
                    Created = new DateTime(2025, 2, 10, 9, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Title = "Started Learning C#",
                    Description = "Excited to start building apps with C# and ASP.NET Core.",
                    Created = new DateTime(2025, 2, 20, 11, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Title = "First Coding Project",
                    Description = "Completed my first small console app today!",
                    Created = new DateTime(2025, 3, 1, 16, 0, 0),
                    Mood = Mood.Grateful
                },
                new DiaryEntry
                {
                    Title = "Rainy Day",
                    Description = "It rained all day, stayed indoors and read a book.",
                    Created = new DateTime(2025, 3, 5, 13, 30, 0),
                    Mood = Mood.Calm
                },
                new DiaryEntry
                {
                    Title = "Gym Motivation",
                    Description = "Had an amazing workout, feeling strong and healthy.",
                    Created = new DateTime(2025, 3, 10, 18, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Title = "Coffee with Friend",
                    Description = "Met an old friend for coffee, great conversation.",
                    Created = new DateTime(2025, 3, 15, 15, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Title = "Learning Guitar",
                    Description = "Practiced guitar for 2 hours, learning a new song.",
                    Created = new DateTime(2025, 3, 20, 17, 0, 0),
                    Mood = Mood.Calm
                },
                new DiaryEntry
                {
                    Title = "Movie Night",
                    Description = "Watched a classic movie and enjoyed every minute.",
                    Created = new DateTime(2025, 3, 25, 20, 0, 0),
                    Mood = Mood.Happy
                },
                new DiaryEntry
                {
                    Title = "Hiking Trip",
                    Description = "Went hiking in the mountains, breathtaking views.",
                    Created = new DateTime(2025, 3, 30, 8, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Title = "Cooking Experiment",
                    Description = "Tried a new recipe today, turned out delicious.",
                    Created = new DateTime(2025, 4, 5, 12, 0, 0),
                    Mood = Mood.Grateful
                },
                new DiaryEntry
                {
                    Title = "Volunteer Work",
                    Description = "Helped at a local shelter, felt very fulfilling.",
                    Created = new DateTime(2025, 4, 10, 9, 30, 0),
                    Mood = Mood.Grateful
                },
                new DiaryEntry
                {
                    Title = "Coding Challenge",
                    Description = "Solved a tricky coding problem, very proud!",
                    Created = new DateTime(2025, 4, 15, 14, 0, 0),
                    Mood = Mood.Excited
                },
                new DiaryEntry
                {
                    Title = "Relaxing Sunday",
                    Description = "Spent the day relaxing, reading, and enjoying music.",
                    Created = new DateTime(2025, 4, 20, 10, 0, 0),
                    Mood = Mood.Calm
                }
            };
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("🛑 Database Cleanup Service is stopping");
            await base.StopAsync(cancellationToken);
        }
    }
}