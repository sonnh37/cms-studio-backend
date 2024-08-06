using MediatR;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class PhotoCommandHandler : BaseCommandHandler<PhotoView>,
    IRequestHandler<PhotoUpdateCommand, MessageView<PhotoView>>,
    IRequestHandler<PhotoDeleteCommand, MessageView<PhotoView>>,
    IRequestHandler<PhotoCreateCommand, MessageView<PhotoView>>
{
    private readonly IPhotoService _photoService;

    public PhotoCommandHandler(IPhotoService photoService) : base(photoService)
    {
        _photoService = photoService;
    }

    public async Task<MessageView<PhotoView>> Handle(PhotoCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _photoService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageView<PhotoView>> Handle(PhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById<PhotoView>(request.Id);
        return msgView;
    }

    public async Task<MessageView<PhotoView>> Handle(PhotoUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}