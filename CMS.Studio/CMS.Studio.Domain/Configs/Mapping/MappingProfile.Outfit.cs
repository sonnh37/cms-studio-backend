using AutoMapper;
using CMS.Studio.Domain.CQRS.Commands.Outfits;
using CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using CMS.Studio.Domain.CQRS.Queries.Outfits.Categories;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Configs.Mapping;

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