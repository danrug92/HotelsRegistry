using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace HotelsRegistry.Application
{
    public static class ApplicationConfig
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            //Add AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Register Mediatr
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        }

    }
}
