using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class Photo : BaseEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }

    public string? Href { get; set; }

    public string? Tag { get; set; }

    public virtual ICollection<ServiceXPhoto> ServiceXPhotos { get; set; } = new List<ServiceXPhoto>();

    public virtual ICollection<AlbumXPhoto> AlbumsXPhotos { get; set; } = new List<AlbumXPhoto>();

    public virtual ICollection<OutfitXPhoto> OutfitXPhotos { get; set; } = new List<OutfitXPhoto>();
}