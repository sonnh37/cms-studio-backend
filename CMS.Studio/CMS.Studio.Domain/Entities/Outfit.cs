using CMS.Studio.Domain.Entities.Bases;
using CMS.Studio.Domain.Enums;

namespace CMS.Studio.Domain.Entities;

public class Outfit : BaseEntity
{
    public string? Sku { get; set; }
    
    public Guid? CategoryId { get; set; }
    
    public Guid? SizeId { get; set; }
    
    public Guid? ColorId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }
    
    public Color? Color { get; set; }
    
    public Category? Category { get; set; }
    
    public Size? Size { get; set; }
    
    public OutfitStatus Status { get; set; }

    public virtual ICollection<OutfitXPhoto> OutfitXPhotos { get; set; } = new List<OutfitXPhoto>();
}