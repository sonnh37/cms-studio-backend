using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Services;

namespace CMS.Studio.API.Registrations;

public static class ServiceRegistration
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IOutfitService, OutfitService>();
        services.AddTransient<IServiceService, ServiceService>();
        services.AddTransient<IPhotoService, PhotoService>();
        services.AddTransient<IAlbumService, AlbumService>();
        services.AddTransient<IAlbumXPhotoService, AlbumXPhotoService>();
        services.AddTransient<IOutfitXPhotoService, OutfitXPhotoService>();
        services.AddTransient<ICategoryService, CategoryService>();
    }
}