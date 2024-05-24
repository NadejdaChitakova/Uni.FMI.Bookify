using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni.FMI.Bookify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCurrencyConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmenitiesUpCharge_Currency",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CleaningFee_Currency",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "PriceForPeriod_Currency",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TotalPrice_Currency",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CleaningFee_Currency",
                table: "Apartment");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Amount",
                table: "Booking",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "PriceForPeriod_Amount",
                table: "Booking",
                newName: "PriceForPeriod");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Amount",
                table: "Booking",
                newName: "CleaningFee");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpCharge_Amount",
                table: "Booking",
                newName: "AmenitiesUpCharge");

            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                table: "Apartment",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "Price_Amount",
                table: "Apartment",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Amount",
                table: "Apartment",
                newName: "CleaningFee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Booking",
                newName: "TotalPrice_Amount");

            migrationBuilder.RenameColumn(
                name: "PriceForPeriod",
                table: "Booking",
                newName: "PriceForPeriod_Amount");

            migrationBuilder.RenameColumn(
                name: "CleaningFee",
                table: "Booking",
                newName: "CleaningFee_Amount");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpCharge",
                table: "Booking",
                newName: "AmenitiesUpCharge_Amount");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Apartment",
                newName: "Price_Currency");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Apartment",
                newName: "Price_Amount");

            migrationBuilder.RenameColumn(
                name: "CleaningFee",
                table: "Apartment",
                newName: "CleaningFee_Amount");

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesUpCharge_Currency",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CleaningFee_Currency",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceForPeriod_Currency",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice_Currency",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CleaningFee_Currency",
                table: "Apartment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
