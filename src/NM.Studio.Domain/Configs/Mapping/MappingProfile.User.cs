using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;

namespace NM.Studio.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void UserMapping()
        {
            CreateMap<User, UserResult>().ReverseMap();
            CreateMap<User, UserCreateCommand>().ReverseMap();
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<User, UserUpdateCommand>().ReverseMap();
        }
    }
}
