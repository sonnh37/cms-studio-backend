using MediatR;
using NM.Studio.Domain.Models.Responses;

namespace NM.Studio.Domain.CQRS.Queries.Users;

public class UserGetByAccountQuery : IRequest<BusinessResult>
{
    public string? account { get; set; }
}