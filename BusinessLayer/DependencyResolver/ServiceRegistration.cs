using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.DependencyResolver;
public static class ServiceRegistration
{
    public static void AddBusinessLayerServices(this IServiceCollection services)
    {
        // Register BusinessLayer dependencies
        services.AddScoped<UserService, UserManager>();
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IHomePageItemService, HomePageItemManager>();
        services.AddScoped<IModelsService, ModelsManager>();
        services.AddScoped<IOpenPositionService, OpenPositionManager>();
        services.AddScoped<IPhotoPageItemService, PhotoPageManager>();
        services.AddScoped<IVideoPageItemService, VideoPageManager>();
        services.AddScoped<IDocumentsPageItemService, DocumentsPageItemManager>();
        services.AddScoped<IReferencesPageItemService, ReferencesPageItemManager>();
        services.AddScoped<ICatalogService, CatalogManager>();
        services.AddScoped<IJobApplicationService, JobApplicationManager>();
        services.AddScoped<IBankAccountService, BankAccountManager>();
        services.AddScoped<IModelDetailService, ModelDetailManeger>();
        services.AddScoped<IModelImageService, ModelImageManager>();
    }
}
