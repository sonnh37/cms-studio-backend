using CMS.Studio.Domain.CQRS.Commands.Base;

namespace CMS.Studio.Domain.CQRS.Commands.AlbumXPhotos;

public class AlbumXPhotoUpdateCommand : UpdateCommand
{
    public Guid? AlbumId { get; set; }

    public Guid? PhotoId { get; set; }
}