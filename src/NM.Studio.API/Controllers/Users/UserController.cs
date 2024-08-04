using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results;

namespace NM.Studio.API.Controllers.Users
{
    [Authorize]
    [Route("user-management/users")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserGetAllQuery userGetAllQuery)
        {
            MessageResults<UserResult> messageResult = await _mediator.Send(userGetAllQuery);

            return Ok(messageResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            UserGetByIdQuery userGetByIdQuery = new UserGetByIdQuery();
            userGetByIdQuery.Id = id;
            MessageResult<UserResult> messageResult = await _mediator.Send(userGetByIdQuery);

            return Ok(messageResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateCommand userCreateCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userCreateCommand);

            return Ok(messageView);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UserUpdateCommand userUpdateCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userUpdateCommand);

            return Ok(messageView);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] UserDeleteCommand userDeleteCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userDeleteCommand);

            return Ok(messageView);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthQuery authQuery)
        {
            MessageLoginResult<UserResult> messageResult = await _mediator.Send(authQuery);
            return Ok(messageResult);
        }

        [AllowAnonymous]
        // POST api/<AuthController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateCommand userCreateCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userCreateCommand);
            return Ok(messageView);
        }
    }
}





