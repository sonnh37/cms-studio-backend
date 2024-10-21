using MediatR;
using NM.Studio.Domain.Models.Responses;

namespace NM.Studio.Domain.CQRS.Queries.Users;

public class UserSendEmailQuery : IRequest<BusinessResult>
{
    public string? Email { get; set; }
}