using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class ServiceXPhoto : BaseEntity
{
    public Guid? ServiceId { get; set; }

    public Guid? PhotoId { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Photo? Photo { get; set; }
}