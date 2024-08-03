using NM.Studio.Domain.Contracts.Repositories.Photos;
using NM.Studio.Domain.Contracts.Repositories.Services;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Data.Context;

namespace NM.Studio.Data.UnitOfWorks
{
    public class UnitOfWork : BaseUnitOfWork<StudioContext>, IUnitOfWork
    {
        public UnitOfWork(StudioContext context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {
        }

        public IUserRepository UserRepository => GetRepository<IUserRepository>();

        public IPhotoRepository PhotoRepository => GetRepository<IPhotoRepository>();

        public IServiceRepository ServiceRepository => GetRepository<IServiceRepository>();

    }
}
