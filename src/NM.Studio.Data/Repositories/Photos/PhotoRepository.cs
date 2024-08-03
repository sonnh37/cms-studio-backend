using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Photos;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Data.Repositories.Photos
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IList<Photo>> GetAllWithInclude(PhotoGetAllQuery query, CancellationToken cancellationToken = default)
        {

            var queryable = GetQueryable();

            // Apply base filtering: not deleted
            queryable = queryable.Where(entity => !entity.IsDeleted);

            // Additional filtering based on PhotoIds (exclude these IDs if given)
            if (query.PhotoIds != null && query.PhotoIds.Count > 0)
            {
                queryable = queryable.Where(entity => !query.PhotoIds.Contains(entity.Id));
            }

            // Include related EventXPhotos

            // Execute the query asynchronously
            var results = await queryable.ToListAsync(cancellationToken);

            return results;

        }
    }
}
