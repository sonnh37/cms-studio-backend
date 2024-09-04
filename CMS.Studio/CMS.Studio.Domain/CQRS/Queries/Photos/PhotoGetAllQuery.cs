using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Photos;

public class PhotoGetAllQuery : GetAllQuery<PhotoResult>
{
    public string? Type { get; set; }
    public Guid? AlbumId { get; set; }
    public Guid? OutfitId { get; set; }
}