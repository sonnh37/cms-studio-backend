using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results;

namespace NM.Studio.API.Controllers.Photos
{
    //[Authorize]
    [Route("photo-management/photos")]
    public class PhotoController : BaseController
    {
        public PhotoController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PhotoGetAllQuery photoGetAllQuery)
        {
            MessageResults<PhotoResult> messageResult = await _mediator.Send(photoGetAllQuery);

            return Ok(messageResult);
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            PhotoGetByIdQuery photoGetByIdQuery = new PhotoGetByIdQuery();
            photoGetByIdQuery.Id = id;
            MessageResult<PhotoResult> messageResult = await _mediator.Send(photoGetByIdQuery);

            return Ok(messageResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhotoCreateCommand photoCreateCommand)
        {
            MessageView<PhotoView> messageView = await _mediator.Send(photoCreateCommand);

            return Ok(messageView);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PhotoUpdateCommand photoUpdateCommand)
        {
            MessageView<PhotoView> messageView = await _mediator.Send(photoUpdateCommand);

            return Ok(messageView);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] PhotoDeleteCommand photoDeleteCommand)
        {
            MessageView<PhotoView> messageView = await _mediator.Send(photoDeleteCommand);

            return Ok(messageView);
        }
    }
}





