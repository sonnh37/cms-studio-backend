using NM.Studio.Domain.CQRS.Commands.Base;

namespace NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;

public class OutfitXPhotoDeleteCommand : DeleteCommand
{
    public Guid? OutfitId { get; set; }

    public Guid? PhotoId { get; set; }
}