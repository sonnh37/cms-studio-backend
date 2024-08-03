using MediatR;
using NM.Studio.Domain.Contracts.Services.Services;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries
{
    public class ServiceQueryHandler : BaseQueryHandler<ServiceView>,
        IRequestHandler<ServiceGetAllQuery, MessageResults<ServiceResult>>,
        IRequestHandler<ServiceGetByIdQuery, MessageResult<ServiceResult>>
    {
        protected readonly IServiceService _serviceService;
        public ServiceQueryHandler(IServiceService serviceService) : base(serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<MessageResults<ServiceResult>> Handle(ServiceGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _serviceService.GetAll(request, cancellationToken);
        }

        public async Task<MessageResult<ServiceResult>> Handle(ServiceGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _serviceService.GetById<ServiceResult>(request.Id);
        }
    }
}
