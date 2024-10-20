using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;

public class AlbumXPhoto : BaseEntity
{
    public Guid? AlbumId { get; set; }

    public Guid? PhotoId { get; set; }

    public virtual Album? Album { get; set; }

    public virtual Photo? Photo { get; set; }
}