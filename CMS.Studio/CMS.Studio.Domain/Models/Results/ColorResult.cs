using CMS.Studio.Domain.Models.Results;
using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Models;

public class ColorResult : BaseResult
{
    public string? Name { get; set; }
    
    public List<OutfitResult> Outfits { get; set; } = new List<OutfitResult>();
}