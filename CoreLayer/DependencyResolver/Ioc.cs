using CoreLayer.Helpers;
using CoreLayer.Utilities.MailUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLayer.DependencyResolver;

public static class Ioc
{
    public static void IocCoreInstall(this IServiceCollection services)
    {
        services.AddSingleton<ZipHelper>();
        services.AddScoped<IMailService, MailManager>();
    }
}
