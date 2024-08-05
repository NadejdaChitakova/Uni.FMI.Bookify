using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni.FMI.Bookify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberOfGuestsInApartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfGuests",
                table: "Apartment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfGuests",
                table: "Apartment");
        }
    }
}
