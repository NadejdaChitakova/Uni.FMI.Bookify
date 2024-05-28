using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni.FMI.Bookify.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationship_Apartment_Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentImage_Apartment_ApartmentId",
                table: "ApartmentImage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApartmentId",
                table: "ApartmentImage",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentImage_Apartment_ApartmentId",
                table: "ApartmentImage",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentImage_Apartment_ApartmentId",
                table: "ApartmentImage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApartmentId",
                table: "ApartmentImage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentImage_Apartment_ApartmentId",
                table: "ApartmentImage",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
