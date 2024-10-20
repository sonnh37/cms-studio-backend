using MediatR;
using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Models.Results;

namespace NM.Studio.Domain.CQRS.Queries.Users;

public class AuthQuery : BaseQuery, IRequest<LoginResponse<UserResult>>
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}