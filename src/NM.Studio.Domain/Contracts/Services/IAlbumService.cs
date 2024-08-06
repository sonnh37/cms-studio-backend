using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services;

public interface IAlbumService : IBaseService
{
    Task<MessageResults<AlbumResult>> GetAll(AlbumGetAllQuery x, CancellationToken cancellationToken = default);
}