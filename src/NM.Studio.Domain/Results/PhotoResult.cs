using NM.Studio.Domain.Results.Bases;

namespace NM.Studio.Domain.Results;

public class PhotoResult : BaseResult
{
    public string? PhotoName { get; set; }

    public string? Url { get; set; }

}