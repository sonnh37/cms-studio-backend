using CMS.Studio.Domain.Contracts.Repositories;

namespace CMS.Studio.Domain.Contracts.UnitOfWorks;

public interface IUnitOfWork : IBaseUnitOfWork
{
    IUserRepository UserRepository { get; }
    IPhotoRepository PhotoRepository { get; }
    IServiceRepository ServiceRepository { get; }

    IOutfitRepository OutfitRepository { get; }
    IAlbumRepository AlbumRepository { get; }
}