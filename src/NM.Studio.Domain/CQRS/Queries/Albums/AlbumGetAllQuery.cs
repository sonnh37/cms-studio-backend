using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.CQRS.Queries.Albums;

public class AlbumGetAllQuery : GetAllQuery<AlbumResult>
{
    public string? Title { get; set; }
}