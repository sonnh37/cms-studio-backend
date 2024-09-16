using AutoMapper;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.Contracts.UnitOfWorks;
using CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Utilities;
using CMS.Studio.Services.Bases;

namespace CMS.Studio.Services;

public class OutfitXPhotoService : BaseService<OutfitXPhoto>, IOutfitXPhotoService
{
    private readonly IOutfitXPhotoRepository _outfitXPhotoRepository;

    public OutfitXPhotoService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _outfitXPhotoRepository = _unitOfWork.OutfitXPhotoRepository;
    }

    public async Task<MessageResponse> DeleteById(OutfitXPhotoDeleteCommand command)
    {
        if (command.OutfitId == Guid.Empty || command.PhotoId == Guid.Empty) return ResponseHelper.CreateMessage(ConstantHelper.NotFound, false);

        var entity = await _outfitXPhotoRepository.GetById(command);
        if (entity == null) return ResponseHelper.CreateMessage(ConstantHelper.NotFound, false);
        _outfitXPhotoRepository.Delete(entity);
        var saveChanges = await _unitOfWork.SaveChanges();
        
        if (!saveChanges) return ResponseHelper.CreateMessage(ConstantHelper.Fail, false);
        
        return ResponseHelper.CreateMessage(ConstantHelper.Success, true);
    }
}