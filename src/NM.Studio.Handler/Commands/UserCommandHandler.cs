using MediatR;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class UserCommandHandler : BaseCommandHandler<UserView>,
    IRequestHandler<UserUpdateCommand, MessageView<UserView>>,
    IRequestHandler<UserDeleteCommand, MessageView<UserView>>,
    IRequestHandler<UserCreateCommand, MessageView<UserView>>
{
    protected readonly IUserService _userService;

    public UserCommandHandler(IUserService userService) : base(userService)
    {
        _userService = userService;
    }

    public async Task<MessageView<UserView>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _userService.Register(request, cancellationToken);
        return msgView;
    }

    public async Task<MessageView<UserView>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById<UserView>(request.Id);
        return msgView;
    }

    public async Task<MessageView<UserView>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}