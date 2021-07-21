using Microsoft.EntityFrameworkCore.Migrations;

namespace PCShop.Migrations
{
    public partial class MoboTableUPD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Platfom",
                table: "Motherboards",
                newName: "Size");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Motherboards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Motherboards");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Motherboards",
                newName: "Platfom");
        }
    }
}
