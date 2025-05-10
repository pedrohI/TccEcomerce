using Microsoft.EntityFrameworkCore;
using TccEcomerce.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<TccEcomerceDbContext>(options =>
    options.UseSqlServer(connectionString));




builder.Services.AddIdentity<Usuario, IdentityRole>(options => {
      options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<TccEcomerceDbContext>()
.AddDefaultTokenProviders();

// Configure Identity options
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Account/Login";
    opts.LogoutPath = "/Account/Logout";
    opts.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await IdentitySeeder.SeedRolesAndAdmin(services); // Seed the database with initial data
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred with identity: {ex.Message}");
    }
}


builder.Logging.AddConsole();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapStaticAssets();



app.Run();

