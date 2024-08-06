using MediatR;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Services;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class ServiceCommandHandler : BaseCommandHandler<ServiceView>,
    IRequestHandler<ServiceCreateCommand, MessageView<ServiceView>>,
    IRequestHandler<ServiceUpdateCommand, MessageView<ServiceView>>,
    IRequestHandler<ServiceDeleteCommand, MessageView<ServiceView>>
{
    protected readonly IServiceService _serviceService;

    public ServiceCommandHandler(IServiceService serviceService) : base(serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<MessageView<ServiceView>> Handle(ServiceCreateCommand request,
        CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageView<ServiceView>> Handle(ServiceDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById<ServiceView>(request.Id);
        return msgView;
    }

    public async Task<MessageView<ServiceView>> Handle(ServiceUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}