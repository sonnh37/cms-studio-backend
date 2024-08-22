using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services;

public class AlbumService : BaseService<Album>, IAlbumService
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _albumRepository = _unitOfWork.AlbumRepository;
    }

    public async Task<MessageResults<AlbumResult>> GetAll(AlbumGetAllQuery x,
        CancellationToken cancellationToken = default)
    {
        var albums = await _albumRepository.GetAllWithInclude(x, cancellationToken);
        // map 
        var content = _mapper.Map<IList<Album>, List<AlbumResult>>(albums);
        var msgResults = AppMessage.GetMessageResults(content);

        return msgResults;
    }
    
    public async Task<MessageResult<AlbumResult>> GetById(AlbumGetByIdQuery x,
        CancellationToken cancellationToken = default)
    {
        var album = await _albumRepository.GetByIdWithInclude(x, cancellationToken);
        // map 
        var content = _mapper.Map<Album, AlbumResult>(album);
        var msgResult = AppMessage.GetMessageResult(content);

        return msgResult;
    }
}