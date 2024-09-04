using CMS.Studio.Domain.Contracts.Services.Bases;
using CMS.Studio.Domain.CQRS.Queries.Albums;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.Contracts.Services;

public interface IAlbumService : IBaseService
{
    Task<PaginatedResponse<AlbumResult>> GetAll(AlbumGetAllQuery x);
}