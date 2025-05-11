using AssetManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(action => { 
    action.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
