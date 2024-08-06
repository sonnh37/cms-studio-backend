using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;

public partial class Album : BaseEntity
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Background { get; set; }
    
    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
}