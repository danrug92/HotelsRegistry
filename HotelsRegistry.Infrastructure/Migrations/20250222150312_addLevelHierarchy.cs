using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelsRegistry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLevelHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HierarchyLevel",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HierarchyLevel",
                table: "RoomTypes");
        }
    }
}
