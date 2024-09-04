using AutoMapper;
using CMS.Studio.Data.Context;
using CMS.Studio.Data.Repositories.Base;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.CQRS.Queries.Outfits;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Utilities;

namespace CMS.Studio.Data.Repositories;

public class OutfitRepository : BaseRepository<Outfit>, IOutfitRepository
{
    public OutfitRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<(List<Outfit>, int)> GetAll(OutfitGetAllQuery query)
    {
        var queryable = GetQueryable();
        queryable = ApplyFilter.Outfit(queryable, query);
        var totalOrigin = queryable.Count();
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }
}