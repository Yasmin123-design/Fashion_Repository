using ClothesStore.Models;
using ClothesStore.Repository;
using ClothesStore.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace ClothesStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //public IConfiguration Configuration { get; }
            
            

        //public IConfiguration Configuration { get; }
           var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddDbContext<ClothesContext>(OptionsBuilder =>
            OptionsBuilder.UseSqlServer("Server=DESKTOP-I7PU4G3;Database=ClothesRepository;Trusted_Connection=True;Encrypt=false")
            );
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ClothesContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // تحديد مدة الجلسة
                options.Cookie.HttpOnly = true; // حماية الكوكيز
                options.Cookie.IsEssential = true;
            });

            // إضافة خدمة عربة التسوق
            builder.Services.AddScoped<ShoppingCartService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            // SeedDatabase(app);
            app.Run();
            
        }
        // to load data in database
        //private static void SeedDatabase(WebApplication app)
        //{
        //    using (var scope = app.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var context = services.GetRequiredService<ClothesContext>();

        //        // تأكد من أن الترحيلات قد طبقت على قاعدة البيانات
        //        context.Database.Migrate();

        //        // تهيئة البيانات (أضف البيانات الأولية هنا)
        //        DBInitializer.Initialize(context);
        //    }
        
    }
}
//private static void SeedDatabase(WebApplication app)
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var services = scope.ServiceProvider;
//        var context = services.GetRequiredService<ClothesContext>();

//        // تأكد من إنشاء قاعدة البيانات
//        context.Database.EnsureCreated();

//        // إضافة البيانات الافتراضية
//        DBInitializer.Initialize(context);

//        // مثال على إدخال بيانات جديدة
//        if (!context.Categories.Any())
//        {
//            var category = new Category
//            {
//                Name = "Sample category",

//            };

//            context.Categories.Add(category);
//            context.SaveChanges();
//        }
//    }
//}
