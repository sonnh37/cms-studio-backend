using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Users;

public class UserDeleteCommand : DeleteCommand<UserView>
{
}