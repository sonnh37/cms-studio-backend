using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NM.Studio.API.Controllers.Photos
{
    [Authorize]
    [Route("api/photo")]
    public class PhotoController : BaseController
    {
        public PhotoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-photo-list")]
        public async Task<IActionResult> GetAll([FromBody] PhotoGetAllQuery photoGetAllQuery)
        {
            MessageResults<PhotoResult> messageResult = await _mediator.Send(photoGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<PhotoController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] PhotoGetByIdQuery photoGetByIdQuery)
        {
            MessageResult<PhotoResult> messageResult = await _mediator.Send(photoGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<PhotoController>
        [HttpPost("create-photo")]
        public async Task<IActionResult> Create([FromBody] PhotoCreateCommand photoCreateCommand)
        {
            MessageView<PhotoView> messageView = await _mediator.Send(photoCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<PhotoController>/5
        [HttpPost("update-photo")]
        public async Task<IActionResult> Update([FromBody] PhotoUpdateCommand photoUpdateCommand)
        {
            MessageView<PhotoView> messageView = await _mediator.Send(photoUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<PhotoController>/5
        [HttpPost("delete-photo")]
        public async Task<IActionResult> Delete([FromBody] PhotoDeleteCommand photoDeleteCommand)
        {
            MessageView<PhotoView> messageView = await _mediator.Send(photoDeleteCommand);
            return Ok(messageView);
        }
    }
}
