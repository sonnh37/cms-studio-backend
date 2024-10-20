using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;

public class Service : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Src { get; set; }

    public decimal? Price { get; set; }

    public TimeSpan? Duration { get; set; }

    public string? Promotion { get; set; }

    public bool IsActive { get; set; }
}