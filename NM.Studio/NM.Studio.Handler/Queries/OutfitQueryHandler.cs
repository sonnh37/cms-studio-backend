using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Models.Results;
using MediatR;

namespace NM.Studio.Handler.Queries;

public class OutfitQueryHandler :
    IRequestHandler<OutfitGetAllQuery, BusinessResult>,
    IRequestHandler<OutfitGetByIdQuery, BusinessResult>
{
    protected readonly IOutfitService _outfitService;

    public OutfitQueryHandler(IOutfitService outfitService)
    {
        _outfitService = outfitService;
    }

    public async Task<BusinessResult> Handle(OutfitGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _outfitService.GetAll<OutfitResult>(request);
    }

    public async Task<BusinessResult> Handle(OutfitGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _outfitService.GetById<OutfitResult>(request.Id);
    }
}