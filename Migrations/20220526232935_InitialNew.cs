using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parish_bookstore.Migrations
{
    public partial class InitialNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AltarItemCategories",
                columns: table => new
                {
                    HomeAltarItemCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltarItemCategories", x => x.HomeAltarItemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.BookCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralItemCategories",
                columns: table => new
                {
                    GeneralItemCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralItemCategories", x => x.GeneralItemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "IconCategories",
                columns: table => new
                {
                    IconCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconCategories", x => x.IconCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PrayerRopes",
                columns: table => new
                {
                    PrayerRopeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnotCount = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerRopes", x => x.PrayerRopeId);
                });

            migrationBuilder.CreateTable(
                name: "AltarItems",
                columns: table => new
                {
                    HomeAltarItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryHomeAltarItemCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltarItems", x => x.HomeAltarItemId);
                    table.ForeignKey(
                        name: "FK_AltarItems_AltarItemCategories_CategoryHomeAltarItemCategoryId",
                        column: x => x.CategoryHomeAltarItemCategoryId,
                        principalTable: "AltarItemCategories",
                        principalColumn: "HomeAltarItemCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookCategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "BookCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralItems",
                columns: table => new
                {
                    GeneralItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryGeneralItemCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralItems", x => x.GeneralItemId);
                    table.ForeignKey(
                        name: "FK_GeneralItems_GeneralItemCategories_CategoryGeneralItemCategoryId",
                        column: x => x.CategoryGeneralItemCategoryId,
                        principalTable: "GeneralItemCategories",
                        principalColumn: "GeneralItemCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Icons",
                columns: table => new
                {
                    IconId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryIconCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.IconId);
                    table.ForeignKey(
                        name: "FK_Icons_IconCategories_CategoryIconCategoryId",
                        column: x => x.CategoryIconCategoryId,
                        principalTable: "IconCategories",
                        principalColumn: "IconCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AltarItemCategories",
                columns: new[] { "HomeAltarItemCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Censers" },
                    { 2, "Charcoal" },
                    { 3, "Incense" },
                    { 4, "Vigil Lamps & Supplies" }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Prayer & Service Books" },
                    { 2, "Fathers & Patristics" },
                    { 3, "Spiritual Development" },
                    { 4, "Church History" },
                    { 5, "Liturgics & Services" }
                });

            migrationBuilder.InsertData(
                table: "GeneralItemCategories",
                columns: new[] { "GeneralItemCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Gifts" },
                    { 2, "Cross Necklaces" },
                    { 3, "Seasonal" }
                });

            migrationBuilder.InsertData(
                table: "IconCategories",
                columns: new[] { "IconCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Christ" },
                    { 2, "Theotokos" },
                    { 3, "Angels" },
                    { 4, "Saints" },
                    { 5, "Feasts" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltarItems_CategoryHomeAltarItemCategoryId",
                table: "AltarItems",
                column: "CategoryHomeAltarItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralItems_CategoryGeneralItemCategoryId",
                table: "GeneralItems",
                column: "CategoryGeneralItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Icons_CategoryIconCategoryId",
                table: "Icons",
                column: "CategoryIconCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltarItems");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "GeneralItems");

            migrationBuilder.DropTable(
                name: "Icons");

            migrationBuilder.DropTable(
                name: "PrayerRopes");

            migrationBuilder.DropTable(
                name: "AltarItemCategories");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "GeneralItemCategories");

            migrationBuilder.DropTable(
                name: "IconCategories");
        }
    }
}
