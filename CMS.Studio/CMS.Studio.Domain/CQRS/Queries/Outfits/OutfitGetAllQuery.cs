using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Enums;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Outfits;

public class OutfitGetAllQuery : GetAllQuery<OutfitResult>
{
    public string? Sku { get; set; }
    
    public Guid? CategoryId { get; set; }
    
    public Guid? SizeId { get; set; }
    
    public Guid? ColorId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }
    
    public OutfitStatus Status { get; set; }
}