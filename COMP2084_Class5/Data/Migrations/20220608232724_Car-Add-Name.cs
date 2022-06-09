using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2084_Class5.Data.Migrations
{
    public partial class CarAddName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Car");
        }
    }
}
