using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Domain.Contracts.Repositories;

public interface IAlbumRepository : IBaseRepository
{
    Task<IList<Album>> GetAllWithInclude(AlbumGetAllQuery x, CancellationToken cancellationToken = default);
}