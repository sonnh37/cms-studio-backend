using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Data.Repositories;

public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
{
    public AlbumRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<IList<Album>> GetAllWithInclude(AlbumGetAllQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable();
        //queryable = queryable.Where(entity => !entity.IsDeleted);
        if (queryable.Any()) queryable = queryable.Include(m => m.Photos);

        var results = await queryable.ToListAsync(cancellationToken);

        return results;
    }
    
    public async Task<Album> GetByIdWithInclude(AlbumGetByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable();
        if (queryable.Any()) queryable = queryable.Include(m => m.Photos);
        if (queryable.Any()) queryable = queryable.Where(m => m.Id == query.Id);

        var result = await queryable.SingleAsync(cancellationToken);

        return result;
    }
}