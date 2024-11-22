using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessLayerServices(this IServiceCollection services)
        {
            // Register DataAccessLayer dependencies
            services.AddScoped<IAuthDal, EfAuthRepository>();
        }
    }
}
