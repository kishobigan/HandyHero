using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class fieldworkerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldWorker",
                table: "FieldWorker");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FieldWorker");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FieldWorker",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldWorker",
                table: "FieldWorker",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldWorker",
                table: "FieldWorker");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FieldWorker");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "FieldWorker",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldWorker",
                table: "FieldWorker",
                column: "Id");
        }
    }
}
