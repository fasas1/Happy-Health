using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Happy_Health.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2007, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Wasiu Ademola" },
                    { 2, new DateTime(1999, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Charles John" },
                    { 3, new DateTime(2009, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Shola Fakuade" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
