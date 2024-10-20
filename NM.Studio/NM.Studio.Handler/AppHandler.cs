using Microsoft.Extensions.DependencyInjection;

namespace NM.Studio.Handler;

public static class AppHandler
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        return services;
    }
}