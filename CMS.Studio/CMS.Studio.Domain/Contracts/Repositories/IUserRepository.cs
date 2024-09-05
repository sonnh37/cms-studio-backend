using CMS.Studio.Domain.Contracts.Repositories.Bases;
using CMS.Studio.Domain.CQRS.Queries.Users;
using CMS.Studio.Domain.Entities;

namespace CMS.Studio.Domain.Contracts.Repositories;

public interface IUserRepository : IBaseRepository
{
    Task<User?> FindUsernameOrEmail(AuthQuery authQuery);

}