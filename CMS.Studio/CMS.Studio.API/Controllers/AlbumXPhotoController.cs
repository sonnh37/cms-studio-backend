using CMS.Studio.API.Controllers.Base;
using CMS.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Studio.API.Controllers;

[Route("albums/albumXPhotos")]
public class AlbumXPhotoController : BaseController
{
    public AlbumXPhotoController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlbumXPhotoCreateCommand command)
    {
        var messageView = await _mediator.Send(command);

        return Ok(messageView);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AlbumXPhotoUpdateCommand command)
    {
        var messageView = await _mediator.Send(command);

        return Ok(messageView);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] AlbumXPhotoDeleteCommand command)
    {
        var messageView = await _mediator.Send(command);

        return Ok(messageView);
    }
}