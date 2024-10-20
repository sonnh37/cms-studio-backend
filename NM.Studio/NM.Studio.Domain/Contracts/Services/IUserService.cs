using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Models.Results;

namespace NM.Studio.Domain.Contracts.Services;

public interface IUserService : IBaseService
{
    Task<LoginResponse<UserResult>> Login(AuthQuery x, CancellationToken cancellationToken = default);
    Task<MessageResponse> Register(UserCreateCommand x, CancellationToken cancellationToken = default);
}