using AutoMapper;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.Contracts.UnitOfWorks;
using CMS.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Utilities;
using CMS.Studio.Services.Bases;

namespace CMS.Studio.Services;

public class AlbumXPhotoService : BaseService<AlbumXPhoto>, IAlbumXPhotoService
{
    private readonly IAlbumXPhotoRepository _albumXPhotoRepository;

    public AlbumXPhotoService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _albumXPhotoRepository = _unitOfWork.AlbumXPhotoRepository;
    }
    
    public async Task<MessageResponse> DeleteById(AlbumXPhotoDeleteCommand command)
    {
        if (command.AlbumId == Guid.Empty || command.PhotoId == Guid.Empty) return ResponseHelper.CreateMessage(ConstantHelper.NotFound, false);

        var entity = await _albumXPhotoRepository.GetById(command);
        if (entity == null) return ResponseHelper.CreateMessage(ConstantHelper.NotFound, false);
        _albumXPhotoRepository.Delete(entity);
        var saveChanges = await _unitOfWork.SaveChanges();
        
        if (!saveChanges) return ResponseHelper.CreateMessage(ConstantHelper.Fail, false);
        
        return ResponseHelper.CreateMessage(ConstantHelper.Success, true);
    }

}