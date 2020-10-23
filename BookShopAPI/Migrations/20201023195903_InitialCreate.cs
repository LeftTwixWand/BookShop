using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShopAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Publication = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cover = table.Column<byte>(type: "INTEGER", nullable: false),
                    AgeCategory = table.Column<byte>(type: "INTEGER", nullable: false),
                    Genre = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeCategory", "Author", "Cover", "Genre", "Publication", "Title" },
                values: new object[] { 1, (byte)2, "John Tolkien", (byte)1, (byte)2, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeCategory", "Author", "Cover", "Genre", "Publication", "Title" },
                values: new object[] { 2, (byte)4, "Stephen William Hawking", (byte)0, (byte)1, new DateTime(1988, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Brief History of Time" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeCategory", "Author", "Cover", "Genre", "Publication", "Title" },
                values: new object[] { 3, (byte)1, "Jules Verne", (byte)1, (byte)2, new DateTime(1870, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Twenty Thousand Leagues Under the Sea" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeCategory", "Author", "Cover", "Genre", "Publication", "Title" },
                values: new object[] { 4, (byte)0, "Antoine de Saint-Exupery", (byte)1, (byte)1, new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Little Prince" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
