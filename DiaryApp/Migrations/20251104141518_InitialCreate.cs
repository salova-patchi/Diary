using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mood = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Created", "Description", "Mood", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "I had an amazing day at my graduation party.", 0, "Graduation Day" },
                    { 2, new DateTime(2025, 1, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), "I was nervous but I think it went well!", 4, "First Job Interview" },
                    { 3, new DateTime(2025, 2, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Spent a relaxing week at the beach with friends.", 0, "Vacation Time" },
                    { 4, new DateTime(2025, 2, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), "Excited to start building apps with C# and ASP.NET Core.", 2, "Started Learning C#" },
                    { 5, new DateTime(2025, 3, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "Completed my first small console app today!", 5, "First Coding Project" },
                    { 6, new DateTime(2025, 3, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), "It rained all day, stayed indoors and read a book.", 3, "Rainy Day" },
                    { 7, new DateTime(2025, 3, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), "Had an amazing workout, feeling strong and healthy.", 2, "Gym Motivation" },
                    { 8, new DateTime(2025, 3, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "Met an old friend for coffee, great conversation.", 0, "Coffee with Friend" },
                    { 9, new DateTime(2025, 3, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), "Practiced guitar for 2 hours, learning a new song.", 3, "Learning Guitar" },
                    { 10, new DateTime(2025, 3, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "Watched a classic movie and enjoyed every minute.", 0, "Movie Night" },
                    { 11, new DateTime(2025, 3, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Went hiking in the mountains, breathtaking views.", 2, "Hiking Trip" },
                    { 12, new DateTime(2025, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Tried a new recipe today, turned out delicious.", 5, "Cooking Experiment" },
                    { 13, new DateTime(2025, 4, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), "Helped at a local shelter, felt very fulfilling.", 5, "Volunteer Work" },
                    { 14, new DateTime(2025, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Solved a tricky coding problem, very proud!", 2, "Coding Challenge" },
                    { 15, new DateTime(2025, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Spent the day relaxing, reading, and enjoying music.", 3, "Relaxing Sunday" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntries");
        }
    }
}
