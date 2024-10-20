using NM.Studio.Domain.CQRS.Commands.Base;

namespace NM.Studio.Domain.CQRS.Commands.Outfits;

public class OutfitCreateCommand : CreateCommand
{
    public string? Type { get; set; }

    public string? Name { get; set; }

    public string? Size { get; set; }

    public decimal? Price { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }
}