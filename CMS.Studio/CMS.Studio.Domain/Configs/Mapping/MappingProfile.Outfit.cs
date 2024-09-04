using AutoMapper;
using CMS.Studio.Domain.CQRS.Commands.Outfits;
using CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void OutfitMapping()
    {
        CreateMap<Outfit, OutfitResult>().ReverseMap();
        CreateMap<Outfit, OutfitCreateCommand>().ReverseMap();
        CreateMap<Outfit, OutfitUpdateCommand>().ReverseMap();
        
        CreateMap<OutfitXPhoto, OutfitXPhotoResult>().ReverseMap();
        CreateMap<OutfitXPhoto, OutfitXPhotoCreateCommand>().ReverseMap();
        CreateMap<OutfitXPhoto, OutfitXPhotoUpdateCommand>().ReverseMap();
    }
}