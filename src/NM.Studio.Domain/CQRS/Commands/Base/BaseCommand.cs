using MediatR;
using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Messages;

namespace NM.Studio.Domain.CQRS.Commands.Base;

public abstract class BaseCommand
{
}

public class CreateOrUpdateCommand<TView> : BaseCommand, IRequest<MessageView<TView>>
    where TView : BaseView
{
}

public class CreateCommand<TView> : CreateOrUpdateCommand<TView>
    where TView : BaseView
{
}

public class UpdateCommand<TView> : CreateOrUpdateCommand<TView>
    where TView : BaseView
{
    public Guid Id { get; set; }
}

public class DeleteCommand<TView> : BaseCommand, IRequest<MessageView<TView>>
    where TView : BaseView
{
    public Guid Id { get; set; }
}