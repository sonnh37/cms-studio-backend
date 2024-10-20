using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Albums;
using NM.Studio.Domain.Models.Responses;
using MediatR;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class AlbumCommandHandler : BaseCommandHandler,
    IRequestHandler<AlbumUpdateCommand, MessageResponse>,
    IRequestHandler<AlbumDeleteCommand, MessageResponse>,
    IRequestHandler<AlbumCreateCommand, MessageResponse>
{
    protected readonly IAlbumService _albumService;

    public AlbumCommandHandler(IAlbumService albumService) : base(albumService)
    {
        _albumService = albumService;
    }

    public async Task<MessageResponse> Handle(AlbumCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _albumService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(AlbumDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById(request.Id);
        return msgView;
    }

    public async Task<MessageResponse> Handle(AlbumUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}