using AutoMapper;
using CMS.Studio.Data.Context;
using CMS.Studio.Data.Repositories.Base;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.CQRS.Queries.Albums;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Utilities;

namespace CMS.Studio.Data.Repositories;

public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
{
    public AlbumRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }


    public async Task<(List<Album>, int)> GetAll(AlbumGetAllQuery query)
    {
        var queryable = GetQueryable();
        queryable = ApplyFilter.Album(queryable, query);
        var totalOrigin = queryable.Count();
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }
}