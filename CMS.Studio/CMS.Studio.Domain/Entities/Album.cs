using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class Album : BaseEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Background { get; set; }

    public virtual ICollection<AlbumXPhoto> AlbumXPhotos { get; set; } = new List<AlbumXPhoto>();
}