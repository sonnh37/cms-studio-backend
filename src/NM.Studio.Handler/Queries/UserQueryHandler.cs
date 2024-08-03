using MediatR;
using NM.Studio.Domain.Contracts.Services.Users;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries
{
    public class UserQueryHandler : BaseQueryHandler<UserView>,
        IRequestHandler<UserGetAllQuery, MessageResults<UserResult>>,
        IRequestHandler<UserGetByIdQuery, MessageResult<UserResult>>,
        IRequestHandler<AuthQuery, MessageLoginResult<UserResult>>

    {
        protected readonly IUserService _userService;
        public UserQueryHandler(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public async Task<MessageResults<UserResult>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAll<UserResult>();
        }

        public async Task<MessageResult<UserResult>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetById<UserResult>(request.Id);
        }

        public async Task<MessageLoginResult<UserResult>> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            var msgView = await _userService.Login(request, cancellationToken);
            return msgView;
        }
    }
}
