using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Models.Results;

public class AlbumXPhotoResult : BaseResult
{
    public Guid? AlbumId { get; set; }

    public Guid? PhotoId { get; set; }

    public AlbumResult? Album { get; set; }

    public PhotoResult? Photo { get; set; }
}