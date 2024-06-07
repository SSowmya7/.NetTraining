using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DtoPractice.Migrations
{
    /// <inheritdoc />
    public partial class AddedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "StudentId");
        }
    }
}
