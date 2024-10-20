using MediatR;
using NM.Studio.Domain.Models.Responses;

namespace NM.Studio.Domain.CQRS.Commands.Base;

public abstract class BaseCommand
{
}

public class CreateOrUpdateCommand : BaseCommand, IRequest<MessageResponse>
{
}

public class CreateCommand : CreateOrUpdateCommand
{
}

public class UpdateCommand : CreateOrUpdateCommand
{
    public Guid Id { get; set; }
}

public class DeleteCommand : BaseCommand, IRequest<MessageResponse>
{
    public Guid Id { get; set; }
}