using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Commands.Photos;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Handler.Commands.Base;
using MediatR;

namespace CMS.Studio.Handler.Commands;

public class PhotoCommandHandler : BaseCommandHandler,
    IRequestHandler<PhotoUpdateCommand, MessageResponse>,
    IRequestHandler<PhotoDeleteCommand, MessageResponse>,
    IRequestHandler<PhotoCreateCommand, MessageResponse>
{
    private readonly IPhotoService _photoService;

    public PhotoCommandHandler(IPhotoService photoService) : base(photoService)
    {
        _photoService = photoService;
    }

    public async Task<MessageResponse> Handle(PhotoCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _photoService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(PhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById(request.Id);
        return msgView;
    }

    public async Task<MessageResponse> Handle(PhotoUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}