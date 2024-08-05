using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Services;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results;

namespace NM.Studio.API.Controllers.Services
{
    //[Authorize]
    [Route("service-management/services")]
    public class ServiceController : BaseController
    {
        public ServiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ServiceGetAllQuery serviceGetAllQuery)
        {
            MessageResults<ServiceResult> messageResult = await _mediator.Send(serviceGetAllQuery);

            return Ok(messageResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            ServiceGetByIdQuery serviceGetByIdQuery = new ServiceGetByIdQuery();
            serviceGetByIdQuery.Id = id;
            MessageResult<ServiceResult> messageResult = await _mediator.Send(serviceGetByIdQuery);

            return Ok(messageResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceCreateCommand serviceCreateCommand)
        {
            MessageView<ServiceView> messageView = await _mediator.Send(serviceCreateCommand);

            return Ok(messageView);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ServiceUpdateCommand serviceUpdateCommand)
        {
            MessageView<ServiceView> messageView = await _mediator.Send(serviceUpdateCommand);

            return Ok(messageView);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] ServiceDeleteCommand serviceDeleteCommand)
        {
            MessageView<ServiceView> messageView = await _mediator.Send(serviceDeleteCommand);

            return Ok(messageView);
        }
    }
}





