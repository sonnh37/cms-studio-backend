using CMS.Studio.API.Controllers.Base;
using CMS.Studio.Domain.CQRS.Commands.Photos;
using CMS.Studio.Domain.CQRS.Queries.Photos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Studio.API.Controllers;

//[Authorize]
[Route("photos")]
public class PhotoController : BaseController
{
    public PhotoController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PhotoGetAllQuery photoGetAllQuery)
    {
        var messageResult = await _mediator.Send(photoGetAllQuery);

        return Ok(messageResult);
    }

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var photoGetByIdQuery = new PhotoGetByIdQuery
        {
            Id = id
        };
        var messageResult = await _mediator.Send(photoGetByIdQuery);

        return Ok(messageResult);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PhotoCreateCommand photoCreateCommand)
    {
        var messageView = await _mediator.Send(photoCreateCommand);

        return Ok(messageView);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PhotoUpdateCommand photoUpdateCommand)
    {
        var messageView = await _mediator.Send(photoUpdateCommand);

        return Ok(messageView);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] PhotoDeleteCommand photoDeleteCommand)
    {
        var messageView = await _mediator.Send(photoDeleteCommand);

        return Ok(messageView);
    }
}