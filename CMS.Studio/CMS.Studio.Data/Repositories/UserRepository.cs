using AutoMapper;
using CMS.Studio.Data.Context;
using CMS.Studio.Data.Repositories.Base;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.CQRS.Queries.Users;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Studio.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<User?> FindUsernameOrEmail(AuthQuery user)
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