using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Models.Results;

public class OutfitResult : BaseResult
{
    public string? Type { get; set; }

    public string? Name { get; set; }

    public string? Size { get; set; }

    public decimal? Price { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }

    public List<PhotoResult> Photos { get; set; } = new();
}