using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Data.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<User> FindUsernameOrEmail(AuthQuery authQuery)
        {
            var queryable = base.GetQueryable();

            // Apply base filtering: not deleted
            queryable = queryable.Where(entity => !entity.IsDeleted);

            // Check username or email
            if (!string.IsNullOrEmpty(authQuery.UserNameOrEmail))
            {
                queryable = queryable.Where(entity => authQuery.UserNameOrEmail.ToLower() == entity.Username.ToLower()
                                            || authQuery.UserNameOrEmail.ToLower() == entity.Email.ToLower()
                );
            }

            // Include related EventXPhotos

            // Execute the query asynchronously
            var result = await queryable.SingleOrDefaultAsync();

            return result;
        }
    }
}
