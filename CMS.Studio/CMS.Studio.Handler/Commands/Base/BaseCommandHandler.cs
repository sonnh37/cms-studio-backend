using CMS.Studio.Domain.Contracts.Services.Bases;
using CMS.Studio.Domain.CQRS.Commands.Base;
using CMS.Studio.Domain.Models.Responses;
using MediatR;

namespace CMS.Studio.Handler.Commands.Base;

public abstract class BaseCommandHandler
{
    protected readonly IBaseService _baseService;

    protected BaseCommandHandler(IBaseService baseService)
    {
        _baseService = baseService;
    }
}