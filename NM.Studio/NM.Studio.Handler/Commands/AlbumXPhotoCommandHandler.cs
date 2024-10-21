using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using NM.Studio.Domain.Models.Responses;
using MediatR;
using NM.Studio.Domain.Models.Results;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class AlbumXPhotoCommandHandler : BaseCommandHandler,
    IRequestHandler<AlbumXPhotoUpdateCommand, BusinessResult>,
    IRequestHandler<AlbumXPhotoDeleteCommand, BusinessResult>,
    IRequestHandler<AlbumXPhotoCreateCommand, BusinessResult>
{
    protected readonly IAlbumXPhotoService _albumXPhotoService;

    public AlbumXPhotoCommandHandler(IAlbumXPhotoService albumXPhotoService) : base(albumXPhotoService)
    {
        _albumXPhotoService = albumXPhotoService;
    }

    public async Task<BusinessResult> Handle(AlbumXPhotoCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _albumXPhotoService.CreateOrUpdate<AlbumXPhotoResult>(request);
        return msgView;
    }

    public async Task<BusinessResult> Handle(AlbumXPhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _albumXPhotoService.DeleteById(request);
        return msgView;
    }

    public async Task<BusinessResult> Handle(AlbumXPhotoUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate<AlbumXPhotoResult>(request);
        return msgView;
    }
}