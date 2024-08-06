using System.ComponentModel.DataAnnotations;

namespace NM.Studio.Domain.Entities.Bases;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}