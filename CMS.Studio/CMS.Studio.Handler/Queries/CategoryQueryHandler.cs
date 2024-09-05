using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Queries.Outfits.Categories;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;
using MediatR;

namespace CMS.Studio.Handler.Queries;

public class CategoryQueryHandler:
    IRequestHandler<CategoryGetAllQuery, TableResponse<CategoryResult>>,
    IRequestHandler<CategoryGetByIdQuery, ItemResponse<CategoryResult>>
{
    protected readonly ICategoryService _categoryService;

    public CategoryQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<TableResponse<CategoryResult>> Handle(CategoryGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _categoryService.GetAll<CategoryResult>(request);
    }

    public async Task<ItemResponse<CategoryResult>> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetById<CategoryResult>(request.Id);
    }
}