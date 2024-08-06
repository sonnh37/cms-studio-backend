using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Handler.Queries.Base;

public abstract class BaseQueryHandler
{
}

public abstract class BaseQueryHandler<TView> : BaseQueryHandler
    where TView : BaseView
{
    protected readonly IBaseService _baseService;

    protected BaseQueryHandler(IBaseService baseService)
    {
        _baseService = baseService;
    }
}