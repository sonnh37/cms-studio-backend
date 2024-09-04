using AutoMapper;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.Contracts.UnitOfWorks;
using CMS.Studio.Domain.CQRS.Queries.Outfits;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;
using CMS.Studio.Domain.Utilities;
using CMS.Studio.Services.Bases;

namespace CMS.Studio.Services;

public class OutfitService : BaseService<Outfit>, IOutfitService
{
    private readonly IOutfitRepository _outfitRepository;

    public OutfitService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _outfitRepository = _unitOfWork.OutfitRepository;
    }

    public async Task<PaginatedResponse<OutfitResult>> GetAll(OutfitGetAllQuery x)
    {
        var outfitWithTotal = await _outfitRepository.GetAll(x);
        var outfitsResult = _mapper.Map<List<OutfitResult>>(outfitWithTotal.Item1);
        var outfitsResultWithTotal = (outfitsResult, outfitWithTotal.Item2);

        return AppResponse.CreatePaginated(outfitsResultWithTotal, x);
    }
}