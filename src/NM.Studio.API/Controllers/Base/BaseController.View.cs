using MediatR;
using NM.Studio.Domain.Models.Base;

namespace NM.Studio.API.Controllers.Base;

public abstract class BaseController<TView> : BaseController where TView : BaseView
{
    protected BaseController(IMediator mediator) : base(mediator)
    {
    }
}