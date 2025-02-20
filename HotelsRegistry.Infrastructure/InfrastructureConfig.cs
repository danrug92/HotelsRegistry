using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelsRegistry.Infrastructure
{
    public static class InfrastructureConfig
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomHierarchyRepository, RoomHierarchyRepository>();
            services.AddScoped<IPricingRepository, PricingRepository>();
        }
    }
}
