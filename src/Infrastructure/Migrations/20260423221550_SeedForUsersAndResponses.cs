using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedForUsersAndResponses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "pablo@example.com", "Pablo" },
                    { 2, new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "camila@example.com", "Camila" }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bienvenidos al foro de estudiantes." },
                    { 2, new DateTime(2026, 4, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, "Gracias por compartir este espacio." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
