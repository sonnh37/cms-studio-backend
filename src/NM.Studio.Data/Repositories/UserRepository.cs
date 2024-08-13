using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<User> FindUsernameOrEmail(AuthQuery user)
    {
        var queryable = GetQueryable();
        queryable = queryable.Where(entity => !entity.IsDeleted);

        if (!string.IsNullOrEmpty(user.Username) || !string.IsNullOrEmpty(user.Email))
            queryable = queryable.Where(entity => user.Username.ToLower() == entity.Username.ToLower()
                                                  || user.Email.ToLower() == entity.Email.ToLower()
            );

        var result = await queryable.SingleOrDefaultAsync();

        return result;
    }
}