using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class Outfit : BaseEntity
{
    public string? Type { get; set; }

    public string? Name { get; set; }

    public string? Size { get; set; }
    
    public decimal? Price { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<OutfitXPhoto> OutfitXPhotos { get; set; } = new List<OutfitXPhoto>();
}