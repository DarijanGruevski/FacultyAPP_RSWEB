using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FacultyApp_RSWEB.Data;
using FacultyApp_RSWEB.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FacultyApp_RSWEBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FacultyApp_RSWEBContext") ?? throw new InvalidOperationException("Connection string 'FacultyApp_RSWEBContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
