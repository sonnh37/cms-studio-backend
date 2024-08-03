using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NM.Studio.API.Controllers.Users
{
    [Authorize]
    [Route("api/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-user-list")]
        public async Task<IActionResult> GetAll([FromBody] UserGetAllQuery userGetAllQuery)
        {
            MessageResults<UserResult> messageResult = await _mediator.Send(userGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<UserController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] UserGetByIdQuery userGetByIdQuery)
        {
            MessageResult<UserResult> messageResult = await _mediator.Send(userGetByIdQuery);
            return Ok(messageResult);
        }

        // PUT api/<UserController>/5
        [HttpPost("update-user")]
        public async Task<IActionResult> Update([FromBody] UserUpdateCommand userUpdateCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userUpdateCommand);
            return Ok(messageView);
        }

        // DELETE api/<UserController>/5
        [HttpPost("delete-user")]
        public async Task<IActionResult> Delete([FromBody] UserDeleteCommand userDeleteCommand)
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
