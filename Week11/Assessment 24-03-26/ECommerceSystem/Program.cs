using ECommerceSystem.Data;
using ECommerceSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DB
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ✅ ADD AUTHENTICATION
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            // ✅ ADD AUTHORIZATION
            builder.Services.AddAuthorization();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ✅ Middleware (ORDER MATTERS)
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();   // 🔥 MUST
            app.UseAuthorization();    // 🔥 MUST

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
