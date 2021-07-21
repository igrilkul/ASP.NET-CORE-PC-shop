using Microsoft.EntityFrameworkCore.Migrations;

namespace PCShop.Migrations
{
    public partial class GPUTableUPD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoostClock",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFans",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoostClock",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "NumberOfFans",
                table: "GPUs");
        }
    }
}
