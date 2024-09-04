using CMS.Studio.API.Controllers.Base;
using CMS.Studio.Domain.CQRS.Commands.Outfits;
using CMS.Studio.Domain.CQRS.Queries.Outfits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Studio.API.Controllers;

//[Authorize]
[Route("outfits")]
public class OutfitController : BaseController
{
    public OutfitController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] OutfitGetAllQuery outfitGetAllQuery)
    {
        var messageResult = await _mediator.Send(outfitGetAllQuery);

        return Ok(messageResult);
    }

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var outfitGetByIdQuery = new OutfitGetByIdQuery
        {
            Id = id
        };
        var messageResult = await _mediator.Send(outfitGetByIdQuery);

        return Ok(messageResult);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OutfitCreateCommand outfitCreateCommand)
    {
        var messageView = await _mediator.Send(outfitCreateCommand);

        return Ok(messageView);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] OutfitUpdateCommand outfitUpdateCommand)
    {
        var messageView = await _mediator.Send(outfitUpdateCommand);

        return Ok(messageView);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] OutfitDeleteCommand outfitDeleteCommand)
    {
        var messageView = await _mediator.Send(outfitDeleteCommand);

        return Ok(messageView);
    }
}