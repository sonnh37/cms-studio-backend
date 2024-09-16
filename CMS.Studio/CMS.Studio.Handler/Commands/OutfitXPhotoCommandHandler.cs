using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Handler.Commands.Base;
using MediatR;

namespace CMS.Studio.Handler.Commands;

public class OutfitXPhotoCommandHandler : BaseCommandHandler,
    IRequestHandler<OutfitXPhotoUpdateCommand, MessageResponse>,
    IRequestHandler<OutfitXPhotoDeleteCommand, MessageResponse>,
    IRequestHandler<OutfitXPhotoCreateCommand, MessageResponse>
{
    protected readonly IOutfitXPhotoService _outfitXPhotoService;

    public OutfitXPhotoCommandHandler(IOutfitXPhotoService outfitXPhotoService) : base(outfitXPhotoService)
    {
        _outfitXPhotoService = outfitXPhotoService;
    }

    public async Task<MessageResponse> Handle(OutfitXPhotoCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _outfitXPhotoService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(OutfitXPhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _outfitXPhotoService.DeleteById(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(OutfitXPhotoUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}