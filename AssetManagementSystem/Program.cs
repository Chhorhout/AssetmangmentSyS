using AssetManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Mapping;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        // options.JsonSerializerOptions.MaxDepth = 2;
    });


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
