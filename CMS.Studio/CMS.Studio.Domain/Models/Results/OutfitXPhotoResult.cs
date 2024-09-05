using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Results.Bases;

namespace CMS.Studio.Domain.Models.Results;

public class OutfitXPhotoResult : BaseResult
{
    public Guid? OutfitId { get; set; }

    public Guid? PhotoId { get; set; }

    public OutfitResult? Outfit { get; set; }

    public PhotoResult? Photo { get; set; }
}