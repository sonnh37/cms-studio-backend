using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Queries.Outfits.Categories;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Handler.Commands.Base;
using MediatR;

namespace CMS.Studio.Handler.Commands;

public class CategoryCommandHandler : BaseCommandHandler,
    IRequestHandler<CategoryUpdateCommand, MessageResponse>,
    IRequestHandler<CategoryDeleteCommand, MessageResponse>,
    IRequestHandler<CategoryCreateCommand, MessageResponse>
{
    protected readonly ICategoryService _categoryService;

    public CategoryCommandHandler(ICategoryService categoryService) : base(categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<MessageResponse> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _categoryService.CreateOrUpdate(request);
        return msgView;
    }

    public async Task<MessageResponse> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.DeleteById(request.Id);
        return msgView;
    }

    public async Task<MessageResponse> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var msgView = await _baseService.CreateOrUpdate(request);
        return msgView;
    }
}