using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ClothesStore.Models
{
    public class ClothesContext : IdentityDbContext<ApplicationUser>
    {
        public ClothesContext() { }
        public ClothesContext(DbContextOptions db) : base(db) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartsItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7PU4G3;Database=ClothesRepository;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تحديد الدقة والمقياس لحقل Price في جدول Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(4, 2); // 18 هو العدد الكلي للأرقام، 2 هو عدد الأرقام بعد الفاصلة العشرية
        }
    }
}
