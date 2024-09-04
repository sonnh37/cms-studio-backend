using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Models.Results;

public class AlbumResult : BaseResult
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Background { get; set; }

    public List<PhotoResult>? Photos { get; set; }
}