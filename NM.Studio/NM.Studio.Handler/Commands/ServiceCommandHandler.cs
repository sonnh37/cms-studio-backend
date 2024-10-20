using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Services;
using NM.Studio.Domain.Models.Responses;
using MediatR;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class ServiceCommandHandler : BaseCommandHandler,
    IRequestHandler<ServiceUpdateCommand, MessageResponse>,
    IRequestHandler<ServiceDeleteCommand, MessageResponse>,
    IRequestHandler<ServiceCreateCommand, MessageResponse>
{
    private readonly IServiceService _serviceService;

    public ServiceCommandHandler(IServiceService serviceService) : base(serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<MessageResponse> Handle(ServiceCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _serviceService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(ServiceDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById(request.Id);
        return msgView;
    }

    public async Task<MessageResponse> Handle(ServiceUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}