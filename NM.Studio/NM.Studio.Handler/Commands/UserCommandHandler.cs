using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Commands.Users;
using NM.Studio.Domain.Models.Responses;
using MediatR;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands;

public class UserCommandHandler : BaseCommandHandler,
    IRequestHandler<UserUpdateCommand, MessageResponse>,
    IRequestHandler<UserDeleteCommand, MessageResponse>,
    IRequestHandler<UserCreateCommand, MessageResponse>
{
    private readonly IUserService _userService;

    public UserCommandHandler(IUserService userService) : base(userService)
    {
        _userService = userService;
    }

    public async Task<MessageResponse> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _userService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById(request.Id);
        return msgView;
    }

    public async Task<MessageResponse> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}