using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeProfilePhotoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Products_ProductsProductId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_OrderDetails_OrderDetailsOrderDetailId",
                table: "OrderDetailProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductsProductId",
                table: "OrderDetailProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "OrderDetailProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsOrderDetailId",
                table: "OrderDetailProduct",
                newName: "OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailProduct_ProductsProductId",
                table: "OrderDetailProduct",
                newName: "IX_OrderDetailProduct_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "CategoryProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "CategoryProduct",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProduct_ProductsProductId",
                table: "CategoryProduct",
                newName: "IX_CategoryProduct_ProductId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePhoto",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Products_ProductId",
                table: "CategoryProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_OrderDetails_OrderDetailId",
                table: "OrderDetailProduct",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductId",
                table: "OrderDetailProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Categories_CategoryId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProduct_Products_ProductId",
                table: "CategoryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_OrderDetails_OrderDetailId",
                table: "OrderDetailProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductId",
                table: "OrderDetailProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetailProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderDetailProduct",
                newName: "OrderDetailsOrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailProduct_ProductId",
                table: "OrderDetailProduct",
                newName: "IX_OrderDetailProduct_ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CategoryProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryProduct",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryProduct_ProductId",
                table: "CategoryProduct",
                newName: "IX_CategoryProduct_ProductsProductId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePhoto",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                table: "CategoryProduct",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProduct_Products_ProductsProductId",
                table: "CategoryProduct",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_OrderDetails_OrderDetailsOrderDetailId",
                table: "OrderDetailProduct",
                column: "OrderDetailsOrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailProduct_Products_ProductsProductId",
                table: "OrderDetailProduct",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
