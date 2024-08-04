using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Contracts.Repositories.Outfits;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM.Studio.Data.Repositories.Outfits
{
    public class OutfitRepository : BaseRepository<Outfit>, IOutfitRepository
    {
        public OutfitRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IList<Outfit>> GetAllWithInclude(OutfitGetAllQuery query, CancellationToken cancellationToken = default)
        {

            var queryable = GetQueryable();

            // Apply base filtering: not deleted
            queryable = queryable.Where(entity => !entity.IsDeleted);

            //// Additional filtering based on OutfitIds (exclude these IDs if given)
            //if (query.OutfitIds != null && query.OutfitIds.Count > 0)
            //{
            //    queryable = queryable.Where(entity => !query.OutfitIds.Contains(entity.Id));
            //}

            // Include related EventXOutfits

            // Execute the query asynchronously
            var results = await queryable.ToListAsync(cancellationToken);

            return results;

        }
    }
}
