using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Happy_Health.Migrations
{
    /// <inheritdoc />
    public partial class SeedAppointmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DateTime", "Description", "DoctorId", "PatientId" },
                values: new object[] { 1, new DateTime(2024, 8, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), "Next week", 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
