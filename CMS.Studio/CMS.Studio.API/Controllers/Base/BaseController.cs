using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Studio.API.Controllers.Base;

[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected BaseController()
    {
    }

    protected BaseController(IMediator mediator) : this()
    {
        _mediator = mediator;
    }
}