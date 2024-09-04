using CMS.Studio.Domain.Contracts.Repositories.Bases;
using CMS.Studio.Domain.Entities.Bases;

namespace CMS.Studio.Domain.Contracts.UnitOfWorks;

public interface IBaseUnitOfWork : IDisposable
{
    IBaseRepository<TEntity> GetRepositoryByEntity<TEntity>() where TEntity : BaseEntity;

    TRepository GetRepository<TRepository>() where TRepository : IBaseRepository;

    Task<bool> SaveChanges(CancellationToken cancellationToken = default);
}