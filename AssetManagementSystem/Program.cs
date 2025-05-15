using AssetManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(action => { 
    action.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
 app.UseCors(builder =>
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("X-Total-Pages", "X-Current-Page", "X-Page-Size", "X-Total-Count")
);

app.UseRouting();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
