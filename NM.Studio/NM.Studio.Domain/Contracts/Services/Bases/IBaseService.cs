using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Models.Results.Bases;

namespace NM.Studio.Domain.Contracts.Services.Bases;

public interface IBaseService
{
    Task<ItemListResponse<TResult>> GetAll<TResult>() where TResult : BaseResult;

    Task<TableResponse<TResult>> GetAll<TResult>(GetQueryableQuery x) where TResult : BaseResult;

    Task<ItemResponse<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult;

    Task<MessageResponse> CreateOrUpdate(CreateOrUpdateCommand createOrUpdateCommand);

    Task<MessageResponse> DeleteById(Guid id);
}