using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.CQRS.Queries.Photos;

public class PhotoGetAllQuery : GetAllQuery<PhotoResult>
{
    public string? Type { get; set; }
    public Guid? AlbumId { get; set; }
    public Guid? OutfitId { get; set; }
}