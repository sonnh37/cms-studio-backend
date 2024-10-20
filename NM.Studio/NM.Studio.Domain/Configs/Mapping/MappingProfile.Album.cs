using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Albums;
using NM.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models.Results;

namespace NM.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void AlbumMapping()
    {
        CreateMap<Album, AlbumResult>().ReverseMap();
        CreateMap<Album, AlbumCreateCommand>().ReverseMap();
        CreateMap<Album, AlbumUpdateCommand>().ReverseMap();

        CreateMap<AlbumXPhoto, AlbumXPhotoResult>().ReverseMap();
        CreateMap<AlbumXPhoto, AlbumXPhotoCreateCommand>().ReverseMap();
        CreateMap<AlbumXPhoto, AlbumXPhotoUpdateCommand>().ReverseMap();
    }
}