using MediatR;
using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Commands.Base
{
    public abstract class BaseCommandHandler
    {
    }
    public abstract class BaseCommandHandler<TView> : BaseCommandHandler,
        IRequestHandler<CreateOrUpdateCommand<TView>, MessageView<TView>>,
        IRequestHandler<DeleteCommand<TView>, MessageView<TView>>
        where TView : BaseView
    {
        protected readonly IBaseService _baseService;

        protected BaseCommandHandler(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<MessageView<TView>> Handle(CreateOrUpdateCommand<TView> request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<TView>(request);
            return msgView;
        }

        public async Task<MessageView<TView>> Handle(DeleteCommand<TView> request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<TView>(request.Id);
            return msgView;
        }
    }
}
