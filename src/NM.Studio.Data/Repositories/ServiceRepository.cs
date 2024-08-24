using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Utilities;

namespace NM.Studio.Data.Repositories;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<IList<Service>> GetAllWithInclude(ServiceGetAllQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable();
        queryable = queryable.Where(entity => !entity.IsDeleted);

        if (query.ServiceIds != null && query.ServiceIds.Count > 0)
            queryable = queryable.Where(entity => !query.ServiceIds.Contains(entity.Id));
        
        if (!string.IsNullOrEmpty(query.Title))
        {
            // Fetch all the data and then filter in memory
            var allAlbums = await queryable.ToListAsync(cancellationToken);
            
            // Apply the Slug transformation in memory
            var filteredAlbums = allAlbums.Where(entity => SlugHelper.ToSlug(entity.Title) == query.Title).ToList();
            Console.Write(filteredAlbums[0].Title);
            return filteredAlbums;
        }

        var results = await queryable.ToListAsync(cancellationToken);

        return results;
    }
}