using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Albums;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.CQRS.Queries.Photos;

namespace NM.Studio.API.Controllers;

//[Authorize]
[Route("album-management/albums")]
public class AlbumController : BaseController
{
    public AlbumController(IMediator mediator, IMapper mapper) : base(mediator)
    {
        _mapper = mapper;
    }
    
    protected readonly IMapper _mapper;

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AlbumGetAllQuery albumGetAllQuery)
    {
        var messageResult = await _mediator.Send(albumGetAllQuery);

        return Ok(messageResult);
    }

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var albumGetByIdQuery = new AlbumGetByIdQuery
        {
            Id = id
        };
        var messageResult = await _mediator.Send(albumGetByIdQuery);

        return Ok(messageResult);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlbumCreateCommand albumCreateCommand)
    {
        var messageView = await _mediator.Send(albumCreateCommand);

        return Ok(messageView);
    }
    
    [HttpPost("{id:guid}/photos")]
    public async Task<IActionResult> CreatePhoto(Guid id, [FromBody] PhotoUpdateCommand photoUpdateCommand)
    {
        photoUpdateCommand.Type = "ALBUM";
        photoUpdateCommand.AlbumId = id;
        var messageView = await _mediator.Send(photoUpdateCommand);

        return Ok(messageView);
    }
    
    [HttpDelete("{id:guid}/photos")]
    public async Task<IActionResult> DeletePhoto(Guid id, [FromQuery] Guid photoId)
    {
        var photoGetByIdQuery = new PhotoGetByIdQuery
        {
            Id = photoId
        };
        var messageResult = await _mediator.Send(photoGetByIdQuery);

        var photoResult = messageResult.Result;
        photoResult.AlbumId = null;
        photoResult.Type = "NONE";

        var photoUpdateCommand = _mapper.Map<PhotoUpdateCommand>(photoResult);
        var messageView = await _mediator.Send(photoUpdateCommand);

        return Ok(messageView);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AlbumUpdateCommand albumUpdateCommand)
    {
        var messageView = await _mediator.Send(albumUpdateCommand);

        return Ok(messageView);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] AlbumDeleteCommand albumDeleteCommand)
    {
        var messageView = await _mediator.Send(albumDeleteCommand);

        return Ok(messageView);
    }
}