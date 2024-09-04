using CMS.Studio.Domain.CQRS.Commands.Base;

namespace CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;

public class OutfitXPhotoCreateCommand : CreateCommand
{
    public Guid? OutfitId { get; set; }

    public Guid? PhotoId { get; set; }   
}