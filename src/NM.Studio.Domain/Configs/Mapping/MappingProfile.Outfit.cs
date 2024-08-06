using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Outfits;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void OutfitMapping()
    {
        CreateMap<Outfit, OutfitResult>().ReverseMap();
        CreateMap<Outfit, OutfitCreateCommand>().ReverseMap();
        CreateMap<Outfit, OutfitView>().ReverseMap();
        CreateMap<Outfit, OutfitUpdateCommand>().ReverseMap();
    }
}