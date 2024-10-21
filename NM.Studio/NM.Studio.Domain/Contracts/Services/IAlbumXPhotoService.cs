using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using NM.Studio.Domain.Models.Responses;

namespace NM.Studio.Domain.Contracts.Services;

public interface IAlbumXPhotoService : IBaseService
{
    Task<BusinessResult> DeleteById(AlbumXPhotoDeleteCommand command);
}