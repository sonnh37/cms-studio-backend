using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    
    private void PhotoMapping()
    {
        CreateMap<Photo, PhotoResult>().ReverseMap();
        CreateMap<Photo, PhotoCreateCommand>().ReverseMap();
        CreateMap<Photo, PhotoView>().ReverseMap();
        CreateMap<Photo, PhotoUpdateCommand>().ReverseMap();
    }
}