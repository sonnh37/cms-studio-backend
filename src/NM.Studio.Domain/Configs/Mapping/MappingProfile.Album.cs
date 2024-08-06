using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Albums;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void AlbumMapping()
    {
        CreateMap<Album, AlbumResult>().ReverseMap();
        CreateMap<Album, AlbumCreateCommand>().ReverseMap();
        CreateMap<Album, AlbumView>().ReverseMap();
        CreateMap<Album, AlbumUpdateCommand>().ReverseMap();
    }
}