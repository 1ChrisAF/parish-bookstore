using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parish_bookstore.Migrations
{
    public partial class ImageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AltarItems_AltarItemCategories_CategoryHomeAltarItemCategoryId",
                table: "AltarItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCategories_BookCategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralItems_GeneralItemCategories_CategoryGeneralItemCategoryId",
                table: "GeneralItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Icons_IconCategories_CategoryIconCategoryId",
                table: "Icons");

            migrationBuilder.DropIndex(
                name: "IX_Icons_CategoryIconCategoryId",
                table: "Icons");

            migrationBuilder.DropIndex(
                name: "IX_GeneralItems_CategoryGeneralItemCategoryId",
                table: "GeneralItems");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_AltarItems_CategoryHomeAltarItemCategoryId",
                table: "AltarItems");

            migrationBuilder.RenameColumn(
                name: "CategoryIconCategoryId",
                table: "Icons",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryGeneralItemCategoryId",
                table: "GeneralItems",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryHomeAltarItemCategoryId",
                table: "AltarItems",
                newName: "CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Icons",
                newName: "CategoryIconCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "GeneralItems",
                newName: "CategoryGeneralItemCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "AltarItems",
                newName: "CategoryHomeAltarItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Icons_CategoryIconCategoryId",
                table: "Icons",
                column: "CategoryIconCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralItems_CategoryGeneralItemCategoryId",
                table: "GeneralItems",
                column: "CategoryGeneralItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AltarItems_CategoryHomeAltarItemCategoryId",
                table: "AltarItems",
                column: "CategoryHomeAltarItemCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AltarItems_AltarItemCategories_CategoryHomeAltarItemCategoryId",
                table: "AltarItems",
                column: "CategoryHomeAltarItemCategoryId",
                principalTable: "AltarItemCategories",
                principalColumn: "HomeAltarItemCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCategories_BookCategoryId",
                table: "Books",
                column: "BookCategoryId",
                principalTable: "BookCategories",
                principalColumn: "BookCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralItems_GeneralItemCategories_CategoryGeneralItemCategoryId",
                table: "GeneralItems",
                column: "CategoryGeneralItemCategoryId",
                principalTable: "GeneralItemCategories",
                principalColumn: "GeneralItemCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Icons_IconCategories_CategoryIconCategoryId",
                table: "Icons",
                column: "CategoryIconCategoryId",
                principalTable: "IconCategories",
                principalColumn: "IconCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
