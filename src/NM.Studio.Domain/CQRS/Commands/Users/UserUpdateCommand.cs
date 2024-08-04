using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Users
{
    public class UserUpdateCommand : UpdateCommand<UserView>
    {
        public string? FullName { get; set; } = null!;

        public string? Email { get; set; }

        public DateTime? Dob { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }

        public string Phone { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? RoleName { get; set; }

        public string? Avatar { get; set; }

        public string? Status { get; set; }
    }
}
