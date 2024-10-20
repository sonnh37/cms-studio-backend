using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using NM.Studio.Domain.Models.Responses;
using MediatR;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class AlbumXPhotoCommandHandler : BaseCommandHandler,
    IRequestHandler<AlbumXPhotoUpdateCommand, MessageResponse>,
    IRequestHandler<AlbumXPhotoDeleteCommand, MessageResponse>,
    IRequestHandler<AlbumXPhotoCreateCommand, MessageResponse>
{
    protected readonly IAlbumXPhotoService _albumXPhotoService;

    public AlbumXPhotoCommandHandler(IAlbumXPhotoService albumXPhotoService) : base(albumXPhotoService)
    {
        _albumXPhotoService = albumXPhotoService;
    }

    public async Task<MessageResponse> Handle(AlbumXPhotoCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _albumXPhotoService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(AlbumXPhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _albumXPhotoService.DeleteById(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(AlbumXPhotoUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}