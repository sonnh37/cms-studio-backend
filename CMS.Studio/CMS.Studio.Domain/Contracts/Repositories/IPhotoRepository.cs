using CMS.Studio.Domain.Contracts.Repositories.Bases;
using CMS.Studio.Domain.CQRS.Queries.Photos;
using CMS.Studio.Domain.Entities;

namespace CMS.Studio.Domain.Contracts.Repositories;

public interface IPhotoRepository : IBaseRepository
{
    Task<(List<Photo>, int)> GetAll(PhotoGetAllQuery x);
}