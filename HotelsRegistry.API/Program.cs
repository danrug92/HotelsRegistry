using HotelsRegistry.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
InfrastructureConfig.AddInfrastructureService(builder.Services, builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.Run();


