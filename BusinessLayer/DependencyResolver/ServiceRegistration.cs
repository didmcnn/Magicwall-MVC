using BusinessLayer.Abstaract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddBusinessLayerServices(this IServiceCollection services)
        {
            // Register BusinessLayer dependencies
            services.AddScoped<IAuthService, AuthManager>();
        }
    }
}
