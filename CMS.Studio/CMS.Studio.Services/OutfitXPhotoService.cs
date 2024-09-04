using AutoMapper;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.Contracts.UnitOfWorks;
using CMS.Studio.Domain.Entities;
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

}