using CMS.Studio.Domain.Contracts.Services.Bases;
using CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using CMS.Studio.Domain.Models.Responses;

namespace CMS.Studio.Domain.Contracts.Services;

public interface IOutfitXPhotoService : IBaseService
{
    Task<MessageResponse> DeleteById(OutfitXPhotoDeleteCommand command);

}