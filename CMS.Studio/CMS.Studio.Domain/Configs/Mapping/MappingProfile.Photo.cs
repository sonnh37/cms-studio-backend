using AutoMapper;
using CMS.Studio.Domain.CQRS.Commands.Photos;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void PhotoMapping()
    {
        CreateMap<Photo, PhotoResult>().ReverseMap();
        CreateMap<Photo, PhotoCreateCommand>().ReverseMap();
        CreateMap<Photo, PhotoUpdateCommand>().ReverseMap();
        CreateMap<PhotoResult, PhotoUpdateCommand>().ReverseMap();
    }
}