using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelsRegistry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccommodationAndRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomCode",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomInfo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SizeInSquareMeters",
                table: "Rooms",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPartOfChain",
                table: "Accommodations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Accommodations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Accommodations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VatNumber",
                table: "Accommodations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomInfo",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SizeInSquareMeters",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "IsPartOfChain",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "VatNumber",
                table: "Accommodations");
        }
    }
}
