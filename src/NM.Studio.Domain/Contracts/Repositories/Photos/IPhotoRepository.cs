using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Domain.Contracts.Repositories.Photos
{
    public interface IPhotoRepository : IBaseRepository
    {
        Task<IList<Photo>> GetAllWithInclude(PhotoGetAllQuery x,CancellationToken cancellationToken = default);
    }
}
