using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Entities;

public class AlbumXPhoto : BaseEntity
{
    public Guid? AlbumId { get; set; }

    public Guid? PhotoId { get; set; }

    public virtual Album? Album { get; set; }

    public virtual Photo? Photo { get; set; }
}