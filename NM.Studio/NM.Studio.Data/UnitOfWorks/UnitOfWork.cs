using NM.Studio.Data.Context;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.Contracts.UnitOfWorks;

namespace NM.Studio.Data.UnitOfWorks;

public class UnitOfWork : BaseUnitOfWork<StudioContext>, IUnitOfWork
{
    public UnitOfWork(StudioContext context, IServiceProvider serviceProvider) : base(context, serviceProvider)
    {
    }

    public IUserRepository UserRepository => GetRepository<IUserRepository>();

    public IPhotoRepository PhotoRepository => GetRepository<IPhotoRepository>();

    public IServiceRepository ServiceRepository => GetRepository<IServiceRepository>();

    public IOutfitRepository OutfitRepository => GetRepository<IOutfitRepository>();

    public IOutfitXPhotoRepository OutfitXPhotoRepository => GetRepository<IOutfitXPhotoRepository>();

    public IAlbumRepository AlbumRepository => GetRepository<IAlbumRepository>();

    public IAlbumXPhotoRepository AlbumXPhotoRepository => GetRepository<IAlbumXPhotoRepository>();

    public ICategoryRepository CategoryRepository => GetRepository<ICategoryRepository>();
}