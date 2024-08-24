using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Utilities;

namespace NM.Studio.Data.Repositories;

public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
{
    public AlbumRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<IList<Album>> GetAllWithInclude(AlbumGetAllQuery query, CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable();

        if (!string.IsNullOrEmpty(query.Title))
        {
            // Fetch all the data and then filter in memory
            var allAlbums = await queryable.Include(m => m.Photos).ToListAsync(cancellationToken);

            // Apply the Slug transformation in memory
            var filteredAlbums = allAlbums.Where(entity => SlugHelper.ToSlug(entity.Title) == query.Title).ToList();
            return filteredAlbums;
        }

        // If no title is provided, fetch all with photos included
        var results = await queryable.Include(m => m.Photos).ToListAsync(cancellationToken);

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