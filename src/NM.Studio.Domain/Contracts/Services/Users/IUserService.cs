using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services.Users
{
    public interface IUserService : IBaseService
    {
        Task<MessageLoginResult<UserResult>> Login(AuthQuery x, CancellationToken cancellationToken = default);
        Task<MessageView<UserView>> Register(UserCreateCommand x, CancellationToken cancellationToken = default);
    }
}
