using AutoMapper;
using CMS.Studio.Domain.CQRS.Commands.Users;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Configs.Mapping;

public partial class MappingProfile : Profile
{
    private void UserMapping()
    {
        CreateMap<User, UserResult>().ReverseMap();
        CreateMap<User, UserCreateCommand>().ReverseMap();
        CreateMap<User, UserUpdateCommand>().ReverseMap();
    }
}