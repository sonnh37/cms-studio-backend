using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using NM.Studio.Domain.Models.Responses;
using MediatR;
using NM.Studio.Domain.Models.Results;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class OutfitXPhotoCommandHandler : BaseCommandHandler,
    IRequestHandler<OutfitXPhotoUpdateCommand, BusinessResult>,
    IRequestHandler<OutfitXPhotoDeleteCommand, BusinessResult>,
    IRequestHandler<OutfitXPhotoCreateCommand, BusinessResult>
{
    protected readonly IOutfitXPhotoService _outfitXPhotoService;

    public OutfitXPhotoCommandHandler(IOutfitXPhotoService outfitXPhotoService) : base(outfitXPhotoService)
    {
        _outfitXPhotoService = outfitXPhotoService;
    }

    public async Task<BusinessResult> Handle(OutfitXPhotoCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _outfitXPhotoService.CreateOrUpdate<OutfitXPhotoResult>(request);
        return msgView;
    }

    public async Task<BusinessResult> Handle(OutfitXPhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _outfitXPhotoService.DeleteById(request);
        return msgView;
    }

    public async Task<BusinessResult> Handle(OutfitXPhotoUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate<OutfitXPhotoResult>(request);
        return msgView;
    }
}