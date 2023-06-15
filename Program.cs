using Microsoft.EntityFrameworkCore;
using System.Configuration;
using School.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer("Server=localhost;Database=School;Trusted_Connection=True;MultipleActiveResultSets=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

/*app.MapGet("/", () => "Hello World!");*/

app.MapControllerRoute(
    name: "report",
    /*pattern: "{controller=Report}/{action}/{discriminator}");*/
    pattern: "{controller=Report}/{action}/{value?}");

/*app.MapControllerRoute(
    name: "people",
    pattern: "{controller=people}/{action}");*/


app.Run();
