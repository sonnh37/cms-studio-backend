using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Messages;


namespace NM.Studio.Domain.Contracts.Services.Bases
{
    public interface IBaseService
    {
        Task<MessageResults<TResult>> GetAll<TResult>() where TResult : BaseResult;

        Task<MessageResult<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult;

        Task<MessageView<TView>> CreateOrUpdate<TView>(CreateOrUpdateCommand<TView> createOrUpdateCommand) where TView : BaseView;

        Task<MessageView<TView>> DeleteById<TView>(Guid id) where TView : BaseView;  


    }
}
