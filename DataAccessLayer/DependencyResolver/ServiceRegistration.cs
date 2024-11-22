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
            services.AddScoped<IUserDal, EfUserRepository>();
            services.AddScoped<IAboutDal,EfAboutRepository>();
            services.AddScoped<IBankAccountDal,EfBankAccountRepository>();
            services.AddScoped<ICatalogDal,EfCatalogRepository>();
            services.AddScoped<IContactDal,EfContactRepository>();
            services.AddScoped<IDocumentsPageItemDal,EfDocumentPageItemRepository>();
            services.AddScoped<IHomePageItemDal,EfHomePageItemRepository>();
            services.AddScoped<IJobApplicationDal,EfJobApplicationRepository>();
            services.AddScoped<IModelPageItemDal,EfModelPageItemRepository>();
            services.AddScoped<IOpenPositionDal,EfOpenPositionRepository>();
            services.AddScoped<IPhotoPageItemDal,EfPhotoPageItemRepository>();
            services.AddScoped<IReferencesPageItemDal,EfReferencesPageItemRepository>();
        }
    }
}
