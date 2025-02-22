using HotelsRegistry.API.Endpoints;
using HotelsRegistry.Application;
using HotelsRegistry.Infrastructure;
using HotelsRegistry.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
// Add services to the container.
InfrastructureConfig.AddInfrastructureService(builder.Services, builder.Configuration);
ApplicationConfig.AddApplicationService(builder.Services);
var app = builder.Build();
//seed data 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync(); 
        await Seeder.SeedAsync(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error on seeding: {ex.Message}");
    }
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.MapAccommodationsEndpoints();
app.MapPricingsEndpoints();
app.MapRoomHierarchysEndpoints();
app.MapRoomTypesEndpoints();
app.MapRoomsEndpoints();
app.Run();


