using AutoMapper;
using CMS.Studio.Domain.CQRS.Commands.Services;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void ServiceMapping()
    {
        CreateMap<Service, ServiceResult>().ReverseMap();
        CreateMap<Service, ServiceCreateCommand>().ReverseMap();
        CreateMap<Service, ServiceUpdateCommand>().ReverseMap();
    }
}