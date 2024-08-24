using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.CQRS.Queries.Services;

public class ServiceGetAllQuery : GetAllQuery<ServiceResult>
{
    public List<Guid>? ServiceIds { get; set; }
    
    public string? Title { get; set; }
}