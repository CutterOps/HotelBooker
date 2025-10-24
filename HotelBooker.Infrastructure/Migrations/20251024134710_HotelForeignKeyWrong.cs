using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HotelForeignKeyWrong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Hotels_Booking",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Booking",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Booking",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Hotels_HotelId",
                table: "Bookings",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Hotels_HotelId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "Booking",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Booking",
                table: "Bookings",
                column: "Booking");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Hotels_Booking",
                table: "Bookings",
                column: "Booking",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
