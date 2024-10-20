﻿using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services;

public class OutfitXPhotoService : BaseService<OutfitXPhoto>, IOutfitXPhotoService
{
    private readonly IOutfitXPhotoRepository _outfitXPhotoRepository;

    public OutfitXPhotoService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _outfitXPhotoRepository = _unitOfWork.OutfitXPhotoRepository;
    }

    public async Task<BusinessResult> DeleteById(OutfitXPhotoDeleteCommand command)
    {
        if (command.OutfitId == Guid.Empty || command.PhotoId == Guid.Empty)
            return ResponseHelper.DeleteData(false);

        var entity = await _outfitXPhotoRepository.GetById(command);
        if (entity == null) return ResponseHelper.DeleteData(false);
        _outfitXPhotoRepository.Delete(entity);
        var saveChanges = await _unitOfWork.SaveChanges();

        if (!saveChanges) return ResponseHelper.DeleteData(false);

        return ResponseHelper.DeleteData(true);
    }
}