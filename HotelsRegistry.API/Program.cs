using HotelsRegistry.API.Endpoints;
using HotelsRegistry.Application;
using HotelsRegistry.Infrastructure;

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

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.MapAccommodationsEndpoints();
app.MapPricingsEndpoints();
app.MapRoomHierarchysEndpoints();
app.MapRoomTypesEndpoints();
app.MapRoomsEndpoints();
app.Run();


