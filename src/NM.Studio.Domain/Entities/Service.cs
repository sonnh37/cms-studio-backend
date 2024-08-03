using System.ComponentModel.DataAnnotations.Schema;
using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;
public partial class Service : BaseEntity
{
    public string? Tittle { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Url { get; set; }

}