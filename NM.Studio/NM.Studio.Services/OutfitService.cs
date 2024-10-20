using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.Entities;
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
}