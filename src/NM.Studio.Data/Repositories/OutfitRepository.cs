using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Data.Repositories;

public class OutfitRepository : BaseRepository<Outfit>, IOutfitRepository
{
    public OutfitRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<IList<Outfit>> GetAllWithInclude(OutfitGetAllQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable();

        if (queryable.Any())
            if (!string.IsNullOrEmpty(query.Type))
                queryable = queryable.Where(m => m.Type.ToLower() == query.Type.ToLower());

        queryable = queryable.Where(entity => !entity.IsDeleted);

        if (queryable.Any()) queryable = queryable.Include(m => m.Photos);

        var results = await queryable.ToListAsync(cancellationToken);

        return results;
    }
}