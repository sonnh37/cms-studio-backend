using MediatR;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries;

public class OutfitQueryHandler : BaseQueryHandler<OutfitView>,
    IRequestHandler<OutfitGetAllQuery, MessageResults<OutfitResult>>,
    IRequestHandler<OutfitGetByIdQuery, MessageResult<OutfitResult>>
{
    protected readonly IOutfitService _outfitService;

    public OutfitQueryHandler(IOutfitService outfitService) : base(outfitService)
    {
        _outfitService = outfitService;
    }

    public async Task<MessageResults<OutfitResult>> Handle(OutfitGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _outfitService.GetAll(request, cancellationToken);
    }

    public async Task<MessageResult<OutfitResult>> Handle(OutfitGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _outfitService.GetById<OutfitResult>(request.Id);
    }
}