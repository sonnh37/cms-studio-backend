using MediatR;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries;

public class AlbumQueryHandler : BaseQueryHandler<AlbumView>,
    IRequestHandler<AlbumGetAllQuery, MessageResults<AlbumResult>>,
    IRequestHandler<AlbumGetByIdQuery, MessageResult<AlbumResult>>
{
    protected readonly IAlbumService _albumService;

    public AlbumQueryHandler(IAlbumService albumService) : base(albumService)
    {
        _albumService = albumService;
    }

    public async Task<MessageResults<AlbumResult>> Handle(AlbumGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _albumService.GetAll(request, cancellationToken);
    }

    public async Task<MessageResult<AlbumResult>> Handle(AlbumGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _albumService.GetById(request, cancellationToken);
    }
}