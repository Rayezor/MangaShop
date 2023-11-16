using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaShop.Migrations
{
    /// <inheritdoc />
    public partial class CartItemDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Mangas_MangaId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "MangaId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Mangas_MangaId",
                table: "CartItems",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Mangas_MangaId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "MangaId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Mangas_MangaId",
                table: "CartItems",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id");
        }
    }
}
