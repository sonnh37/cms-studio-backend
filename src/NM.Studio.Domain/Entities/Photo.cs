using System.ComponentModel.DataAnnotations.Schema;
using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;

public partial class Photo : BaseEntity
{
    public string? Type { get; set; }

    public string? Url { get; set; }

}