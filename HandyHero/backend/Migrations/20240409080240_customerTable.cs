using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class customerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            // Drop the Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customer");

            // Add a new Id column with the correct data type and identity specification
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customer",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Set the new Id column as the primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            // Drop the Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customer");

            // Add the old Id column back with the previous data type and identity specification
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Set the old Id column as the primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");
        }
    }
}
