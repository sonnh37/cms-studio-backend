using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Outfits;

public class OutfitGetAllQuery : GetAllQuery<OutfitResult>
{
    public string? Type { get; set; }

    public string? Name { get; set; }

    public string? Size { get; set; }
    
    public decimal? Price { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }
}