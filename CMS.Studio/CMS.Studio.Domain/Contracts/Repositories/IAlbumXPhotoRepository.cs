using CMS.Studio.Domain.Contracts.Repositories.Bases;
using CMS.Studio.Domain.Contracts.Services.Bases;
using CMS.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using CMS.Studio.Domain.Entities;

namespace CMS.Studio.Domain.Contracts.Repositories;

public interface IAlbumXPhotoRepository : IBaseRepository
{
    Task<AlbumXPhoto?> GetById(AlbumXPhotoDeleteCommand command);
    void Delete(AlbumXPhoto entity);
}