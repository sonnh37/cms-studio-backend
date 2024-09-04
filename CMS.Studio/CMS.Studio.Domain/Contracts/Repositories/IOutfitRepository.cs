using CMS.Studio.Domain.Contracts.Repositories.Bases;
using CMS.Studio.Domain.CQRS.Queries.Outfits;
using CMS.Studio.Domain.Entities;

namespace CMS.Studio.Domain.Contracts.Repositories;

public interface IOutfitRepository : IBaseRepository
{
    Task<(List<Outfit>, int)> GetAll(OutfitGetAllQuery x);
}