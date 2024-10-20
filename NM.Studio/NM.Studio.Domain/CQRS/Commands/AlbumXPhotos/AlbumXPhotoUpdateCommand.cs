using NM.Studio.Domain.CQRS.Commands.Base;

namespace NM.Studio.Domain.CQRS.Commands.AlbumXPhotos;

public class AlbumXPhotoUpdateCommand : UpdateCommand
{
    public Guid? AlbumId { get; set; }

    public Guid? PhotoId { get; set; }
}