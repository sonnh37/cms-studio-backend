using CMS.Studio.Domain.CQRS.Commands.Base;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Contracts.Services.Bases;

public interface IBaseService
{
    Task<ItemListResponse<TResult>> GetAll<TResult>() where TResult : BaseResult;

    Task<ItemResponse<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult;

    Task<MessageResponse> CreateOrUpdate(CreateOrUpdateCommand createOrUpdateCommand);

    Task<MessageResponse> DeleteById(Guid id);
}