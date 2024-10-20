using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models.Results;

namespace NM.Studio.Domain.Configs.Mapping;

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