using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class Size : BaseEntity
{
    public string? Name { get; set; }
    
    public virtual ICollection<Outfit> Outfits { get; set; } = new List<Outfit>();
}