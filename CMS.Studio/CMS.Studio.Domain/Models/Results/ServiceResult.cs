using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Models.Results;

public class ServiceResult : BaseResult
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }
}