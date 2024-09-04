using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Albums;

public class AlbumGetAllQuery : GetAllQuery<AlbumResult>
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Background { get; set; }
}