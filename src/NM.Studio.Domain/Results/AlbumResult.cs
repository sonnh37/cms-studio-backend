using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Results.Bases;

namespace NM.Studio.Domain.Results;

public class AlbumResult : BaseResult
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Background { get; set; }

    public List<Album> Albums { get; set; } = new();
}