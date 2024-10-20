using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Models.Results;
using MediatR;

namespace NM.Studio.Handler.Queries;

public class UserQueryHandler :
    IRequestHandler<UserGetAllQuery, TableResponse<UserResult>>,
    IRequestHandler<UserGetByIdQuery, ItemResponse<UserResult>>
{
    protected readonly IUserService _userService;

    public UserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<TableResponse<UserResult>> Handle(UserGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _userService.GetAll<UserResult>(request);
    }

    public async Task<ItemResponse<UserResult>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetById<UserResult>(request.Id);
    }
}