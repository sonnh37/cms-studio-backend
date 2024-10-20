using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Outfits;
using NM.Studio.Domain.Models.Responses;
using MediatR;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class OutfitCommandHandler : BaseCommandHandler,
    IRequestHandler<OutfitCreateCommand, MessageResponse>,
    IRequestHandler<OutfitUpdateCommand, MessageResponse>,
    IRequestHandler<OutfitDeleteCommand, MessageResponse>
{
    protected readonly IOutfitService _serviceOutfit;

    public OutfitCommandHandler(IOutfitService serviceOutfit) : base(serviceOutfit)
    {
        _serviceOutfit = serviceOutfit;
    }

    public async Task<MessageResponse> Handle(OutfitCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(OutfitDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById(request.Id);
        return msgView;
    }

    public async Task<MessageResponse> Handle(OutfitUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}