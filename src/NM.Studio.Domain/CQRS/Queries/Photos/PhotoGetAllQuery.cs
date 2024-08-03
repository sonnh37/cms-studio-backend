using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.CQRS.Queries.Photos
{
    public class PhotoGetAllQuery : GetAllQuery<PhotoResult>
    {
        public List<Guid> PhotoIds { get; set; } = new List<Guid>();
    }
}
