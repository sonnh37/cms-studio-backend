using NM.Studio.Domain.Results.Bases;

namespace NM.Studio.Domain.Results;

public class ServiceResult : BaseResult
{
    public string? Tittle { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Url { get; set; }
}