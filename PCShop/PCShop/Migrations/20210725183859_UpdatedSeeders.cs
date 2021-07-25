using Microsoft.EntityFrameworkCore.Migrations;

namespace PCShop.Migrations
{
    public partial class UpdatedSeeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxSpeed",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinSpeed",
                table: "Products",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaxSpeed",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinSpeed",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Speed",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
