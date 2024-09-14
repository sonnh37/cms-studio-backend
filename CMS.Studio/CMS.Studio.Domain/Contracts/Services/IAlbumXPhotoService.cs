using CMS.Studio.Domain.Contracts.Services.Bases;
using CMS.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using CMS.Studio.Domain.Models.Responses;

namespace CMS.Studio.Domain.Contracts.Services;

public interface IAlbumXPhotoService : IBaseService
{
    Task<MessageResponse> DeleteById(AlbumXPhotoDeleteCommand command);
}