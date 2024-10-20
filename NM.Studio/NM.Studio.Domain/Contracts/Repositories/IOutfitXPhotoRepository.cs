using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Domain.Contracts.Repositories;

public interface IOutfitXPhotoRepository : IBaseRepository
{
    Task<OutfitXPhoto?> GetById(OutfitXPhotoDeleteCommand command);
    void Delete(OutfitXPhoto entity);
}