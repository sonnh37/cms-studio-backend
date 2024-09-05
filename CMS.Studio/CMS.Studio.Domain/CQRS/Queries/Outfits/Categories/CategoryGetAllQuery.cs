using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Outfits.Categories;

public class CategoryGetAllQuery : GetAllQuery<CategoryResult>
{
    public string? Name { get; set; }
}