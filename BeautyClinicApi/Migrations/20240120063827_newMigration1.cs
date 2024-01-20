using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class newMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductId",
                table: "OrderDetailProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductId",
                table: "OrderDetailProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductId",
                table: "OrderDetailProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductId",
                table: "OrderDetailProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
