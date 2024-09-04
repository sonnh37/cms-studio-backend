using AutoMapper;
using CMS.Studio.Domain.CQRS.Commands.Albums;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void AlbumMapping()
    {
        CreateMap<Album, AlbumResult>().ReverseMap();
        CreateMap<Album, AlbumCreateCommand>().ReverseMap();
        CreateMap<Album, AlbumUpdateCommand>().ReverseMap();
    }
}