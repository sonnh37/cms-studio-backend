using MediatR;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Outfits;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class OutfitCommandHandler : BaseCommandHandler<OutfitView>,
    IRequestHandler<OutfitCreateCommand, MessageView<OutfitView>>,
    IRequestHandler<OutfitUpdateCommand, MessageView<OutfitView>>,
    IRequestHandler<OutfitDeleteCommand, MessageView<OutfitView>>
{
    protected readonly IOutfitService _serviceOutfit;

    public OutfitCommandHandler(IOutfitService serviceOutfit) : base(serviceOutfit)
    {
        _serviceOutfit = serviceOutfit;
    }

    public async Task<MessageView<OutfitView>> Handle(OutfitCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageView<OutfitView>> Handle(OutfitDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById<OutfitView>(request.Id);
        return msgView;
    }

    public async Task<MessageView<OutfitView>> Handle(OutfitUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}