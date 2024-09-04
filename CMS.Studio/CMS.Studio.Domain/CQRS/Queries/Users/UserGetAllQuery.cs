using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Enums;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Users;

public class UserGetAllQuery : GetAllQuery<UserResult>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public Role? Role { get; set; }

    public string? Avatar { get; set; }

    public string? Status { get; set; }
}