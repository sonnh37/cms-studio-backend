using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Models.Results;

namespace CMS.Studio.Domain.CQRS.Queries.Outfits;

public class OutfitGetAllQuery : GetAllQuery<OutfitResult>
{
    public string? Type { get; set; }
}