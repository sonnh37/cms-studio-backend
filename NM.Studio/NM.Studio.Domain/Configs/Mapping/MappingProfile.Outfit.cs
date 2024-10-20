using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Outfits;
using NM.Studio.Domain.CQRS.Commands.Outfits.Categories;
using NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models.Results;

namespace NM.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void OutfitMapping()
    {
        CreateMap<Outfit, OutfitResult>().ReverseMap();
        CreateMap<Outfit, OutfitCreateCommand>().ReverseMap();
        CreateMap<Outfit, OutfitUpdateCommand>().ReverseMap();

        CreateMap<Color, ColorResult>().ReverseMap();
        CreateMap<Size, SizeResult>().ReverseMap();

        CreateMap<Category, CategoryResult>().ReverseMap();
        CreateMap<Category, CategoryCreateCommand>().ReverseMap();
        CreateMap<Category, CategoryUpdateCommand>().ReverseMap();


        CreateMap<OutfitXPhoto, OutfitXPhotoResult>().ReverseMap();
        CreateMap<OutfitXPhoto, OutfitXPhotoCreateCommand>().ReverseMap();
        CreateMap<OutfitXPhoto, OutfitXPhotoUpdateCommand>().ReverseMap();
    }
}