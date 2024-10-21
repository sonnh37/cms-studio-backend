using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;

namespace NM.Studio.API.Controllers;

[Authorize]
[Route("users")]
public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] UserGetAllQuery userGetAllQuery)
    {
        var messageResult = await _mediator.Send(userGetAllQuery);

        return Ok(messageResult);
    }

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var userGetByIdQuery = new UserGetByIdQuery
        {
            Id = id
        };
        var messageResult = await _mediator.Send(userGetByIdQuery);

        return Ok(messageResult);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateCommand userCreateCommand)
    {
        var messageView = await _mediator.Send(userCreateCommand);

        return Ok(messageView);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] UserUpdateCommand userUpdateCommand)
    {
        var messageView = await _mediator.Send(userUpdateCommand);

        return Ok(messageView);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] UserDeleteCommand userDeleteCommand)
    {
        var messageView = await _mediator.Send(userDeleteCommand);

        return Ok(messageView);
    }
    
    [HttpGet("account")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAccount([FromQuery] UserGetByAccountQuery request)
    {
        var msg = await _mediator.Send(request);
        return Ok(msg);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthQuery authQuery)
    {
        var messageResult = await _mediator.Send(authQuery);
        return Ok(messageResult);
    }

    [AllowAnonymous]
    // POST api/<AuthController>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateCommand request)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        request.Password = passwordHash;
        
        var messageView = await _mediator.Send(request);
        return Ok(messageView);
    }
    
    [HttpPost("decode-token")]
   
    public async Task<IActionResult> DecodeToken([FromBody] DecodedTokenQuery request)
    {
        var messageView = await _mediator.Send(request);
        return Ok(messageView);
    }

    [AllowAnonymous]
    [HttpPost("send-email")]
    public async Task<IActionResult> SendOTP([FromBody] UserSendEmailQuery request)
    {
        var messageView = await _mediator.Send(request);
        return Ok(messageView);
    }

    [AllowAnonymous]
    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOTP([FromBody] VerifyOTPQuery request)
    {
        var messageView = await _mediator.Send(request);
        return Ok(messageView);
    }



    [AllowAnonymous]
    [HttpPost("find-account-registered-by-google")]
    public async Task<IActionResult> FindAccountRegisteredByGoogle([FromBody] UserGetByGoogleTokenQuery request)
    {
        var messageView = await _mediator.Send(request);
        return Ok(messageView);
    }

    [AllowAnonymous]
    [HttpPost("login-by-google")]
    public async Task<IActionResult> LoginByGoogle([FromBody] AuthByGoogleTokenQuery request)
    {
        var messageView = await _mediator.Send(request);
        return Ok(messageView);
    }

    [AllowAnonymous]
    [HttpPost("register-by-google")]
    public async Task<IActionResult> RegisterByGoogle([FromBody] UserCreateByGoogleTokenCommand request)
    {
        var messageView = await _mediator.Send(request);
        return Ok(messageView);
    }
}