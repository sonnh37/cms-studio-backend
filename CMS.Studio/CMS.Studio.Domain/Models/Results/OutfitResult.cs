using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Enums;
using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Models.Results;

public class OutfitResult : BaseResult
{
    public string? Sku { get; set; }
    
    public Guid? CategoryId { get; set; }
    
    public Guid? SizeId { get; set; }
    
    public Guid? ColorId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }
    
    public ColorResult? Color { get; set; }
    
    public CategoryResult? Category { get; set; }
    
    public SizeResult? Size { get; set; }
    
    public OutfitStatus Status { get; set; }

    public List<OutfitXPhotoResult> OutfitXPhotos { get; set; } = new List<OutfitXPhotoResult>();
}