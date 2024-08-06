using MediatR;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Albums;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class AlbumCommandHandler : BaseCommandHandler<AlbumView>,
    IRequestHandler<AlbumUpdateCommand, MessageView<AlbumView>>,
    IRequestHandler<AlbumDeleteCommand, MessageView<AlbumView>>,
    IRequestHandler<AlbumCreateCommand, MessageView<AlbumView>>
{
    protected readonly IAlbumService _albumService;

    public AlbumCommandHandler(IAlbumService albumService) : base(albumService)
    {
        _albumService = albumService;
    }

    public async Task<MessageView<AlbumView>> Handle(AlbumCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _albumService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageView<AlbumView>> Handle(AlbumDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById<AlbumView>(request.Id);
        return msgView;
    }

    public async Task<MessageView<AlbumView>> Handle(AlbumUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}