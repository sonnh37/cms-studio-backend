using AutoMapper;
using Serilog;
using NM.Studio.Domain.Contracts.Repositories.Services;
using NM.Studio.Domain.Contracts.Services.Services;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Results;
using Microsoft.AspNetCore.Http;

namespace NM.Studio.Services
{
    public class ServiceService : BaseService<Service>, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IMapper mapper,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) 
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _serviceRepository = _unitOfWork.ServiceRepository;
        }
        public async Task<MessageResults<ServiceResult>> GetAll(ServiceGetAllQuery x, CancellationToken cancellationToken = default)
        {
            var services = await _serviceRepository.GetAllWithInclude(x, cancellationToken);
            // map 
            var content = _mapper.Map<IList<Service>, List<ServiceResult>>(services);
            var msgResults = AppMessage.GetMessageResults(content);

            return msgResults;
        }

    }
}
