using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Services;

public class ServiceGetAllQuery : GetAllQuery<ServiceResult>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Src { get; set; }
    
    public decimal? Price { get; set; }
    
    public TimeSpan? Duration { get; set; }
    
    public string? Promotion { get; set; }
    
    public bool IsActive { get; set; }
}