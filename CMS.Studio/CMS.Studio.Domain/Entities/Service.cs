using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class Service : BaseEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }

    public virtual ICollection<ServiceXPhoto> ServiceXPhotos { get; set; } = new List<ServiceXPhoto>();
}