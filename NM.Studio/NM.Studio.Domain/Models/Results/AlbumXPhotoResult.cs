using NM.Studio.Domain.Models.Results.Bases;

namespace NM.Studio.Domain.Models.Results;

public class AlbumXPhotoResult : BaseResult
{
    public Guid? AlbumId { get; set; }

    public Guid? PhotoId { get; set; }

    public AlbumResult? Album { get; set; }

    public PhotoResult? Photo { get; set; }
}