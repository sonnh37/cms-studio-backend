using MediatR;
using NM.Studio.Domain.Models.Responses;

namespace NM.Studio.Domain.CQRS.Queries.Users;

public class VerifyOTPQuery : IRequest<BusinessResult>
{
    public string? Email { get; set; }
    public string? Otp { get; set; }
}