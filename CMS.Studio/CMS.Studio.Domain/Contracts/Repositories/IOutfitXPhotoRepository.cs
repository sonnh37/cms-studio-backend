using CMS.Studio.Domain.Contracts.Repositories.Bases;
using CMS.Studio.Domain.Contracts.Services.Bases;
using CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using CMS.Studio.Domain.Entities;

namespace CMS.Studio.Domain.Contracts.Repositories;

public interface IOutfitXPhotoRepository : IBaseRepository
{
    Task<OutfitXPhoto?> GetById(OutfitXPhotoDeleteCommand command);
    void Delete(OutfitXPhoto entity);
}