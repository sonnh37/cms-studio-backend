using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Outfits;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results;

namespace NM.Studio.API.Controllers.Outfits
{
    [Authorize]
    [Route("outfit-management/outfits")]
    public class OutfitController : BaseController
    {
        public OutfitController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OutfitGetAllQuery outfitGetAllQuery)
        {
            MessageResults<OutfitResult> messageResult = await _mediator.Send(outfitGetAllQuery);

            return Ok(messageResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            OutfitGetByIdQuery outfitGetByIdQuery = new OutfitGetByIdQuery();
            outfitGetByIdQuery.Id = id;
            MessageResult<OutfitResult> messageResult = await _mediator.Send(outfitGetByIdQuery);

            return Ok(messageResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OutfitCreateCommand outfitCreateCommand)
        {
            MessageView<OutfitView> messageView = await _mediator.Send(outfitCreateCommand);

            return Ok(messageView);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OutfitUpdateCommand outfitUpdateCommand)
        {
            MessageView<OutfitView> messageView = await _mediator.Send(outfitUpdateCommand);

            return Ok(messageView);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] OutfitDeleteCommand outfitDeleteCommand)
        {
            MessageView<OutfitView> messageView = await _mediator.Send(outfitDeleteCommand);

            return Ok(messageView);
        }
    }
}





