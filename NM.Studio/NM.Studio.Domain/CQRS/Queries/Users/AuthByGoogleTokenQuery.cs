using MediatR;
using NM.Studio.Domain.Models.Responses;

namespace NM.Studio.Domain.CQRS.Queries.Users;

public class AuthByGoogleTokenQuery : IRequest<BusinessResult>
{
    public string? Token { get; set; }
}