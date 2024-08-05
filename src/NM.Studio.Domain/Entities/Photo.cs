using System.ComponentModel.DataAnnotations.Schema;
using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities;

public partial class Photo : BaseEntity
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Type { get; set; }

    public string? Src { get; set; }
    
    public string? Href { get; set; }

}