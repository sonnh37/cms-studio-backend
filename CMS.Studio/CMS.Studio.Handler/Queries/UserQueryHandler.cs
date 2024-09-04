using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Queries.Users;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;
using MediatR;

namespace CMS.Studio.Handler.Queries;

public class UserQueryHandler :
    IRequestHandler<UserGetAllQuery, PaginatedResponse<UserResult>>,
    IRequestHandler<UserGetByIdQuery, ItemResponse<UserResult>>
{
    protected readonly IUserService _userService;

    public UserQueryHandler(IUserService userService) 
    {
        _userService = userService;
    }

    public async Task<PaginatedResponse<UserResult>> Handle(UserGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _userService.GetAll(request);
    }

    public async Task<ItemResponse<UserResult>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetById<UserResult>(request.Id);
    }
}