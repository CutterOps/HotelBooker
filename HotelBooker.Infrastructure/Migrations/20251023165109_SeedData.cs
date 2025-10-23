using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "BookingRef", "City", "Country", "Name", "PostalCode", "Region" },
                values: new object[,]
                {
                    { new Guid("13ab1a14-801b-419c-a388-0032ebb7adbb"), "1200 Ocean View Drive", "Tower B, Suite 10", "A742", "Santa Monica", "USA", "Pacific Shores Resort & Spa", "90401", "CA" },
                    { new Guid("3e4eba53-7b38-4698-9740-8076d0d2957e"), "25 Rue de Rivoli", "", "C1550", "Paris", "France", "Le Petit Jardin Hotel", "75004", "Île-de-France" },
                    { new Guid("77aeb7e5-5f9f-4913-9fc2-9f310d5102b5"), "Threadneedle Street", "City of London", "B931", "London", "UK", "The Royal Exchange Grand", "EC2R 8AH", "England" },
                    { new Guid("976eab2e-519e-48c8-8895-157946836f3b"), "1 Chome-24-2 Nishi-Shinjuku", "Shinjuku City", "D33", "Tokyo", "Japan", "Shinjuku Sky Tower Inn", "160-0023", "Tokyo" },
                    { new Guid("cb33a5de-772b-4c9e-920b-03e09417c78c"), "142 George Street", "The Rocks", "E8802", "Sydney", "Australia", "The Harbour View Residence", "2000", "NSW" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("13ab1a14-801b-419c-a388-0032ebb7adbb"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("3e4eba53-7b38-4698-9740-8076d0d2957e"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("77aeb7e5-5f9f-4913-9fc2-9f310d5102b5"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("976eab2e-519e-48c8-8895-157946836f3b"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("cb33a5de-772b-4c9e-920b-03e09417c78c"));
        }
    }
}
