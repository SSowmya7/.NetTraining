using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCustomerwithProducts.Migrations
{
    /// <inheritdoc />
    public partial class entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CustomersWithProducts_CustomersWithProductsCustomerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CustomersWithProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_CustomersWithProductsCustomerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomersWithProductsCustomerId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CustomersWithProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersWithProduct", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersWithProduct");

            migrationBuilder.AddColumn<int>(
                name: "CustomersWithProductsCustomerId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomersWithProducts",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersWithProducts", x => x.CustomerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomersWithProductsCustomerId",
                table: "Products",
                column: "CustomersWithProductsCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CustomersWithProducts_CustomersWithProductsCustomerId",
                table: "Products",
                column: "CustomersWithProductsCustomerId",
                principalTable: "CustomersWithProducts",
                principalColumn: "CustomerId");
        }
    }
}
