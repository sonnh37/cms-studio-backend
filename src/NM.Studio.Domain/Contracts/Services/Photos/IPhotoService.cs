using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services.Photos
{
    public interface IPhotoService : IBaseService
    {
        Task<MessageResults<PhotoResult>> GetAll(PhotoGetAllQuery x, CancellationToken cancellationToken = default);
    }
}
