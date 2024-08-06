using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services;

public interface IOutfitService : IBaseService
{
    Task<MessageResults<OutfitResult>> GetAll(OutfitGetAllQuery x, CancellationToken cancellationToken = default);
}