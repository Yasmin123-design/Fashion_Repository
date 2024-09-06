using Microsoft.EntityFrameworkCore;
namespace ClothesStore.Models
{
    public static  class DBInitializer
    {
        public static void Initialize(ClothesContext context)
        {
            // التأكد من إنشاء قاعدة البيانات
            context.Database.EnsureCreated();

          

            // إضافة البيانات الافتراضية لفئة "Category"
            var categories = new List<Category>
            {
                new Category { Name = "T-Shirts" },
                new Category { Name = "Pants" },
                new Category { Name = "Shoes" },
                new Category { Name = "Jackets" },
                new Category { Name = "Accessories" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            // إضافة البيانات الافتراضية لفئة "Product"
            var products = new List<Product>
            {
                // T-Shirts
                new Product { Name = "Red T-Shirt", Description = "Comfortable cotton t-shirt", Price = 29.99m, Size = "M", Image = "red-tshirt.jpg", CategoryId = categories[0].Id, IsPreferred = true },
                new Product { Name = "Blue T-Shirt", Description = "Soft blue cotton t-shirt", Price = 24.99m, Size = "L", Image = "blue-tshirt.jpg", CategoryId = categories[0].Id, IsPreferred = false },
                new Product { Name = "Black T-Shirt", Description = "Classic black t-shirt", Price = 19.99m, Size = "S", Image = "black-tshirt.jpg", CategoryId = categories[0].Id, IsPreferred = false },
                new Product { Name = "White T-Shirt", Description = "Simple white t-shirt", Price = 14.99m, Size = "M", Image = "white-tshirt.jpg", CategoryId = categories[0].Id, IsPreferred = false },
                new Product { Name = "Green T-Shirt", Description = "Vibrant green t-shirt", Price = 22.99m, Size = "L", Image = "green-tshirt.jpg", CategoryId = categories[0].Id, IsPreferred = true },

                // Pants
                new Product { Name = "Blue Jeans", Description = "Stylish blue jeans", Price = 49.99m, Size = "32", Image = "blue-jeans.jpg", CategoryId = categories[1].Id, IsPreferred = false },
                new Product { Name = "Black Jeans", Description = "Comfortable black jeans", Price = 54.99m, Size = "34", Image = "black-jeans.jpg", CategoryId = categories[1].Id, IsPreferred = true },
                new Product { Name = "Khaki Pants", Description = "Classic khaki pants", Price = 39.99m, Size = "32", Image = "khaki-pants.jpg", CategoryId = categories[1].Id, IsPreferred = false },
                new Product { Name = "Grey Sweatpants", Description = "Soft and comfortable sweatpants", Price = 29.99m, Size = "L", Image = "grey-sweatpants.jpg", CategoryId = categories[1].Id, IsPreferred = true },
                new Product { Name = "Cargo Pants", Description = "Durable cargo pants", Price = 44.99m, Size = "M", Image = "cargo-pants.jpg", CategoryId = categories[1].Id, IsPreferred = false },

                // Shoes
                new Product { Name = "Running Shoes", Description = "Lightweight running shoes", Price = 89.99m, Size = "42", Image = "running-shoes.jpg", CategoryId = categories[2].Id, IsPreferred = true },
                new Product { Name = "Leather Boots", Description = "Durable leather boots", Price = 19.99m, Size = "44", Image = "leather-boots.jpg", CategoryId = categories[2].Id, IsPreferred = false },
                new Product { Name = "Sandals", Description = "Comfortable summer sandals", Price = 39.99m, Size = "40", Image = "sandals.jpg", CategoryId = categories[2].Id, IsPreferred = true },
                new Product { Name = "Sneakers", Description = "Casual sneakers", Price = 74.99m, Size = "43", Image = "sneakers.jpg", CategoryId = categories[2].Id, IsPreferred = false },
                new Product { Name = "Dress Shoes", Description = "Elegant dress shoes", Price = 12.99m, Size = "42", Image = "dress-shoes.jpg", CategoryId = categories[2].Id, IsPreferred = true },

                // Jackets
                new Product { Name = "Leather Jacket", Description = "Classic black leather jacket", Price = 199.99m, Size = "L", Image = "leather-jacket.jpg", CategoryId = categories[3].Id, IsPreferred = true },
                new Product { Name = "Denim Jacket", Description = "Stylish denim jacket", Price = 89.99m, Size = "M", Image = "denim-jacket.jpg", CategoryId = categories[3].Id, IsPreferred = false },
                new Product { Name = "Winter Coat", Description = "Warm winter coat", Price = 149.99m, Size = "XL", Image = "winter-coat.jpg", CategoryId = categories[3].Id, IsPreferred = true },
                new Product { Name = "Bomber Jacket", Description = "Trendy bomber jacket", Price = 99.99m, Size = "M", Image = "bomber-jacket.jpg", CategoryId = categories[3].Id, IsPreferred = false },
                new Product { Name = "Rain Jacket", Description = "Waterproof rain jacket", Price = 69.99m, Size = "L", Image = "rain-jacket.jpg", CategoryId = categories[3].Id, IsPreferred = false },

                // Accessories
                new Product { Name = "Leather Belt", Description = "Premium leather belt", Price = 29.99m, Size = "One Size", Image = "leather-belt.jpg", CategoryId = categories[4].Id, IsPreferred = true },
                new Product { Name = "Wool Scarf", Description = "Warm wool scarf", Price = 19.99m, Size = "One Size", Image = "wool-scarf.jpg", CategoryId = categories[4].Id, IsPreferred = false },
                new Product { Name = "Beanie Hat", Description = "Cozy beanie hat", Price = 14.99m, Size = "One Size", Image = "beanie-hat.jpg", CategoryId = categories[4].Id, IsPreferred = true },
                new Product { Name = "Sunglasses", Description = "Stylish sunglasses", Price = 49.99m, Size = "One Size", Image = "sunglasses.jpg", CategoryId = categories[4].Id, IsPreferred = false },
                new Product { Name = "Leather Wallet", Description = "Compact leather wallet", Price = 39.99m, Size = "One Size", Image = "leather-wallet.jpg", CategoryId = categories[4].Id, IsPreferred = true }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
