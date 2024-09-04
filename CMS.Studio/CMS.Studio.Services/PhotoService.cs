using AutoMapper;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.Contracts.UnitOfWorks;
using CMS.Studio.Domain.CQRS.Queries.Photos;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;
using CMS.Studio.Domain.Utilities;
using CMS.Studio.Services.Bases;

namespace CMS.Studio.Services;

public class PhotoService : BaseService<Photo>, IPhotoService
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _photoRepository = _unitOfWork.PhotoRepository;
    }

    public async Task<PaginatedResponse<PhotoResult>> GetAll(PhotoGetAllQuery x)
    {
        var photoWithTotal = await _photoRepository.GetAll(x);
        var photosResult = _mapper.Map<List<PhotoResult>>(photoWithTotal.Item1);
        var photosResultWithTotal = (photosResult, photoWithTotal.Item2);

        return AppResponse.CreatePaginated(photosResultWithTotal, x);
    }
}