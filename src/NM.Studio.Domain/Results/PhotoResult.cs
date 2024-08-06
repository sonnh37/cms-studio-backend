using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Results.Bases;

namespace NM.Studio.Domain.Results;

public class PhotoResult : BaseResult
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }

    public string? Href { get; set; }

    public Guid? AlbumId { get; set; }

    public Album? Album { get; set; }
}