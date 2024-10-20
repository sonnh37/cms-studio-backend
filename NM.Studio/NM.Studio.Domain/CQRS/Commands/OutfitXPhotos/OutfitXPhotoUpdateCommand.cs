using NM.Studio.Domain.CQRS.Commands.Base;

namespace NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;

public class OutfitXPhotoUpdateCommand : UpdateCommand
{
    public Guid? OutfitId { get; set; }

    public Guid? PhotoId { get; set; }
}