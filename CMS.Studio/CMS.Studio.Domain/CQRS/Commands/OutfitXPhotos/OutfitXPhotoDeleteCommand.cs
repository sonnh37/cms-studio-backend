using CMS.Studio.Domain.CQRS.Commands.Base;

namespace CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;

public class OutfitXPhotoDeleteCommand : DeleteCommand
{
    public Guid? OutfitId { get; set; }

    public Guid? PhotoId { get; set; }    
}