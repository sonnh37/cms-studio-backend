using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;

public class Service : BaseEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }
}