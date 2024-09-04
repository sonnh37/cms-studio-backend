using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Albums;

public class AlbumGetAllQuery : GetAllQuery<AlbumResult>
{
    public string? Title { get; set; }
}