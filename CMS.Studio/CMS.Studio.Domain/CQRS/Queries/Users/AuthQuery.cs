using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;
using MediatR;

namespace CMS.Studio.Domain.CQRS.Queries.Users;

public class AuthQuery : BaseQuery, IRequest<LoginResponse<UserResult>>
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}