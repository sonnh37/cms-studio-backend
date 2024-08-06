using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models;

public class OutfitView : BaseView
{
    public string? Type { get; set; }

    public string? Name { get; set; }

    public string? Size { get; set; }

    public decimal? Price { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }
}