using CMS.Studio.API.Controllers.Base;
using CMS.Studio.Domain.CQRS.Commands.Services;
using CMS.Studio.Domain.CQRS.Queries.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Studio.API.Controllers;

//[Authorize]
[Route("service-management/services")]
public class ServiceController : BaseController
{
    public ServiceController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ServiceGetAllQuery serviceGetAllQuery)
    {
        var messageResult = await _mediator.Send(serviceGetAllQuery);

        return Ok(messageResult);
    }

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var serviceGetByIdQuery = new ServiceGetByIdQuery
        {
            Id = id
        };
        var messageResult = await _mediator.Send(serviceGetByIdQuery);

        return Ok(messageResult);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ServiceCreateCommand serviceCreateCommand)
    {
        var messageView = await _mediator.Send(serviceCreateCommand);

        return Ok(messageView);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ServiceUpdateCommand serviceUpdateCommand)
    {
        var messageView = await _mediator.Send(serviceUpdateCommand);

        return Ok(messageView);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] ServiceDeleteCommand serviceDeleteCommand)
    {
        var messageView = await _mediator.Send(serviceDeleteCommand);

        return Ok(messageView);
    }
}