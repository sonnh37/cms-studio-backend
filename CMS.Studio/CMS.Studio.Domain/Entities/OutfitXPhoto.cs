using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class OutfitXPhoto : BaseEntity
{
    public Guid? OutfitId { get; set; }

    public Guid? PhotoId { get; set; }

    public virtual Outfit? Outfit { get; set; }

    public virtual Photo? Photo { get; set; }
}