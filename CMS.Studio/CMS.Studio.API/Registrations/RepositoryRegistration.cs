using CMS.Studio.Data.Repositories;
using CMS.Studio.Data.UnitOfWorks;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.UnitOfWorks;

namespace CMS.Studio.API.Registrations;

public static class RepositoryRegistration
{
    public static void AddCustomRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOutfitRepository, OutfitRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IAlbumRepository, AlbumRepository>();
    }
}