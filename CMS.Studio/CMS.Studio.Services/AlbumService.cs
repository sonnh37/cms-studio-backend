using AutoMapper;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.Contracts.UnitOfWorks;
using CMS.Studio.Domain.CQRS.Queries.Albums;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;
using CMS.Studio.Domain.Utilities;
using CMS.Studio.Services.Bases;

namespace CMS.Studio.Services;

public class AlbumService : BaseService<Album>, IAlbumService
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _albumRepository = _unitOfWork.AlbumRepository;
    }

    public async Task<PaginatedResponse<AlbumResult>> GetAll(AlbumGetAllQuery x)
    {
        var albumWithTotal = await _albumRepository.GetAll(x);
        var albumsResult = _mapper.Map<List<AlbumResult>>(albumWithTotal.Item1);
        var albumsResultWithTotal = (albumsResult, albumWithTotal.Item2);

        return AppResponse.CreatePaginated(albumsResultWithTotal, x);
    }
}