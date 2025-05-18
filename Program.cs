using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using SupermarketWEB.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        // ✅ Configuración de autenticación usando el esquema "Cookies"
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
     {
         options.Cookie.Name = "MyCookieAuth"; // El nombre de la COOKIE es personalizable
         options.LoginPath = "/Account/Login";
     });

        // Agregando el contexto SupermarketContext a la aplicación
        builder.Services.AddDbContext<SupermarketContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SupermarketDB"))
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();  // 👈 Necesario para la autenticación
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
