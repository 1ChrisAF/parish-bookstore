using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parish_bookstore.Migrations
{
    public partial class CartMigration : Migration
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
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
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
                name: "Temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "AltarItemCategories",
                columns: new[] { "HomeAltarItemCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "unassigned" },
                    { 2, "Censers" },
                    { 3, "Charcoal" },
                    { 4, "Incense" },
                    { 5, "Vigil Lamps & Supplies" }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "unassigned" },
                    { 2, "Prayer & Service Books" },
                    { 3, "Fathers & Patristics" },
                    { 4, "Spiritual Development" },
                    { 5, "Church History" },
                    { 6, "Liturgics & Services" }
                });

            migrationBuilder.InsertData(
                table: "GeneralItemCategories",
                columns: new[] { "GeneralItemCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "unassigned" },
                    { 2, "Gifts" },
                    { 3, "Cross Necklaces" },
                    { 4, "Seasonal" }
                });

            migrationBuilder.InsertData(
                table: "IconCategories",
                columns: new[] { "IconCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "unassigned" },
                    { 2, "Christ" },
                    { 3, "Theotokos" },
                    { 4, "Angels" },
                    { 5, "Saints" },
                    { 6, "Feasts" }
                });

            migrationBuilder.InsertData(
                table: "Temp",
                columns: new[] { "Id", "ImageName" },
                values: new object[] { 1, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltarItemCategories");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "GeneralItemCategories");

            migrationBuilder.DropTable(
                name: "IconCategories");

            migrationBuilder.DropTable(
                name: "Temp");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
