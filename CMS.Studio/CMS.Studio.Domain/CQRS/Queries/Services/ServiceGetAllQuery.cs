using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Services;

public class ServiceGetAllQuery : GetAllQuery<ServiceResult>
{
    public List<Guid>? ServiceIds { get; set; }

    public string? Title { get; set; }
}