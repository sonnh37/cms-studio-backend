using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Commands.Users;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Handler.Commands.Base;
using MediatR;

namespace CMS.Studio.Handler.Commands;

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