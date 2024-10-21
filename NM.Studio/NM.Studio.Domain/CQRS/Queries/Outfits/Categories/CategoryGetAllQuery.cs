using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Models.Results;

namespace NM.Studio.Domain.CQRS.Queries.Outfits.Categories;

public class CategoryGetAllQuery : GetAllQuery
{
    public string? Name { get; set; }
}