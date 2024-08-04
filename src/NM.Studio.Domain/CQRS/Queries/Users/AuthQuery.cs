using MediatR;
using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.CQRS.Queries.Users
{
    public class AuthQuery : BaseQuery, IRequest<MessageLoginResult<UserResult>>
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
