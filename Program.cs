using TestWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.DB.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorOptions(
    options => {// Add custom location to view search location
        options.ViewLocationFormats.Add("/Views/Login/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/Projects/{0}.cshtml");
    });

builder.Services.AddSession();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<TestAppDbContext>(item => item.UseNpgsql(config.GetConnectionString("DBConnectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

await app.MigrateDatabase();

app.Run();
