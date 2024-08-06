using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;

public class Photo : BaseEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }

    public string? Href { get; set; }

    public Guid? AlbumId { get; set; }

    public virtual Album? Album { get; set; }
}