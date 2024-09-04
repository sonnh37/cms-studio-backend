using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Services;

public class ServiceGetAllQuery : GetAllQuery<ServiceResult>
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }

}