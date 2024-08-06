using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Services;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Data.Repositories.Services
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public async Task<IList<Service>> GetAllWithInclude(ServiceGetAllQuery query, CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            queryable = queryable.Where(entity => !entity.IsDeleted);

            if (query.ServiceIds != null && query.ServiceIds.Count > 0)
            {
                queryable = queryable.Where(entity => !query.ServiceIds.Contains(entity.Id));
            }

            var results = await queryable.ToListAsync(cancellationToken);

            return results;
        }
    }
}
