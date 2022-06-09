using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2084_Class5.Data.Migrations
{
    public partial class CarnEngine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Car",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Car",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_EngineId",
                table: "Car",
                column: "EngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Engine_EngineId",
                table: "Car",
                column: "EngineId",
                principalTable: "Engine",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Engine_EngineId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Car_EngineId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
