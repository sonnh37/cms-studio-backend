using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Domain.Contracts.Repositories;

public interface IOutfitRepository : IBaseRepository
{
    Task<IList<Outfit>> GetAllWithInclude(OutfitGetAllQuery query, CancellationToken cancellationToken = default);
}