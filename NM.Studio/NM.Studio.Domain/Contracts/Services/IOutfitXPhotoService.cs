using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using NM.Studio.Domain.Models.Responses;

namespace NM.Studio.Domain.Contracts.Services;

public interface IOutfitXPhotoService : IBaseService
{
    Task<BusinessResult> DeleteById(OutfitXPhotoDeleteCommand command);
}