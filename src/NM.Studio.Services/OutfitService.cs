using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services;

public class OutfitService : BaseService<Outfit>, IOutfitService
{
    private readonly IOutfitRepository _outfitRepository;

    public OutfitService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _outfitRepository = _unitOfWork.OutfitRepository;
    }

    public async Task<MessageResults<OutfitResult>> GetAll(OutfitGetAllQuery x,
        CancellationToken cancellationToken = default)
    {
        var outfits = await _outfitRepository.GetAllWithInclude(x, cancellationToken);
        // map 
        var content = _mapper.Map<IList<Outfit>, List<OutfitResult>>(outfits);
        var msgResults = AppMessage.GetMessageResults(content);

        return msgResults;
    }
}