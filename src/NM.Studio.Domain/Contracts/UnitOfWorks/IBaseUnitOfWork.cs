using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Contracts.UnitOfWorks
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepositoryByEntity<TEntity>() where TEntity: BaseEntity;  

        TRepository GetRepository<TRepository>() where TRepository: IBaseRepository;

        Task<bool> SaveChanges(CancellationToken cancellationToken = default);
    }
}
