using AutoMapper;
using CMS.Studio.Data.Context;
using CMS.Studio.Data.Repositories.Base;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.CQRS.Queries.Services;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Utilities;

namespace CMS.Studio.Data.Repositories;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<(List<Service>, int)> GetAll(ServiceGetAllQuery query)
    {
        var queryable = GetQueryable();
        queryable = ApplyFilter.Service(queryable, query);
        var totalOrigin = queryable.Count();
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }
}