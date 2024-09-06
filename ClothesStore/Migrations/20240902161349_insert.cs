using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesStore.Migrations
{
    /// <inheritdoc />
    public partial class insert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // إضافة بيانات ابتدائية إلى جدول Categories
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name" },
                values: new object[,]
                {
                  { "T-Shirts" },
                  { "Pants" },
                  { "Accessories" },
                  { "Shorts" }
                });

            // إضافة بيانات ابتدائية إلى جدول Products
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Size", "Image", "CategoryId", "IsPreferred" },
                values: new object[,]
                {
                  { "Cool T-Shirt", "High-quality cotton T-shirt", 15.99m, "Medium", "cool_tshirt.jpg", 1, true },
                  { "Graphic T-Shirt", "T-shirt with a cool graphic print", 19.99m, "Large", "graphic_tshirt.jpg", 1, true },
                  { "Slim Fit Jeans", "Comfortable slim fit jeans", 39.99m, "32", "slim_fit_jeans.jpg", 2, false },
                  { "Cargo Pants", "Durable cargo pants with multiple pockets", 49.99m, "34", "cargo_pants.jpg", 2, true },
                  { "Stylish Sunglasses", "Trendy sunglasses for summer", 12.99m, "One Size", "sunglasses.jpg", 3, false },
                  { "Leather Wallet", "Premium leather wallet", 29.99m, "One Size", "leather_wallet.jpg", 3, true },
                  { "Casual Shorts", "Comfortable shorts for casual wear", 25.99m, "Medium", "casual_shorts.jpg", 4, true },
                  { "Sports Shorts", "Athletic shorts for sports activities", 22.99m, "Large", "sports_shorts.jpg", 4, false },
                  { "Elegant Scarf", "Warm and elegant scarf", 18.99m, "One Size", "elegant_scarf.jpg", 3, true },
                  { "Designer Belt", "High-quality designer belt", 34.99m, "Medium", "designer_belt.jpg", 3, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
