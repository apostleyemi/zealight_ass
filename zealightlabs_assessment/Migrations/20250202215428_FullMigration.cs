using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zealightlabs_assessment.Migrations
{
    /// <inheritdoc />
    public partial class FullMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Clothings" },
                    { 3, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Delicious cheese pizza", "Pizza", 9.99m },
                    { 2, 1, "Juicy beef burger", "Burger", 5.99m },
                    { 3, 1, "Italian pasta with sauce", "Pasta", 7.99m },
                    { 4, 1, "Fresh vegetable salad", "Salad", 4.99m },
                    { 5, 1, "Crispy fried chicken", "Fried Chicken", 8.99m },
                    { 6, 2, "Cotton T-shirt", "T-shirt", 12.99m },
                    { 7, 2, "Comfortable denim jeans", "Jeans", 29.99m },
                    { 8, 2, "Winter jacket", "Jacket", 49.99m },
                    { 9, 2, "Warm wool sweater", "Sweater", 39.99m },
                    { 10, 2, "Elegant skirt for women", "Skirt", 22.99m },
                    { 11, 3, "High-performance laptop", "Laptop", 799.99m },
                    { 12, 3, "Latest smartphone with great features", "Smartphone", 699.99m },
                    { 13, 3, "Noise-cancelling headphones", "Headphones", 199.99m },
                    { 14, 3, "Wearable fitness tracker", "Smart Watch", 129.99m },
                    { 15, 3, "LED Smart TV with 4K resolution", "TV", 499.99m },
                    { 16, 1, "Pepperoni pizza", "Pizza", 10.99m },
                    { 17, 1, "Chicken sandwich with veggies", "Sandwich", 6.49m },
                    { 18, 1, "Vanilla and chocolate ice cream", "Ice Cream", 3.99m },
                    { 19, 1, "Glazed donut", "Donut", 2.99m },
                    { 20, 1, "Grilled steak", "Steak", 15.99m },
                    { 21, 2, "Casual summer shorts", "Shorts", 18.99m },
                    { 22, 2, "Women's blouse", "Blouse", 24.99m },
                    { 23, 2, "Leather shoes", "Shoes", 59.99m },
                    { 24, 2, "Formal dress", "Dress", 49.99m },
                    { 25, 2, "Baseball cap", "Cap", 14.99m },
                    { 26, 3, "Android tablet", "Tablet", 299.99m },
                    { 27, 3, "Gaming console with two controllers", "Game Console", 399.99m },
                    { 28, 3, "Bluetooth portable speaker", "Speaker", 89.99m },
                    { 29, 3, "Digital camera with zoom", "Camera", 249.99m },
                    { 30, 3, "LED smart bulb with remote control", "Smart Bulb", 19.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
