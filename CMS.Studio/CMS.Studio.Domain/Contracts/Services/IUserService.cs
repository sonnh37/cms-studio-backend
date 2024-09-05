using CMS.Studio.Domain.Contracts.Services.Bases;
using CMS.Studio.Domain.CQRS.Commands.Users;
using CMS.Studio.Domain.CQRS.Queries.Users;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Contracts.Services;

public interface IUserService : IBaseService
{
    Task<LoginResponse<UserResult>> Login(AuthQuery x, CancellationToken cancellationToken = default);
    Task<MessageResponse> Register(UserCreateCommand x, CancellationToken cancellationToken = default);

}