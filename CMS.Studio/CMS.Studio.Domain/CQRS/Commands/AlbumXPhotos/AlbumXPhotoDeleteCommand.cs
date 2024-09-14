using CMS.Studio.Domain.CQRS.Commands.Base;

namespace CMS.Studio.Domain.CQRS.Commands.AlbumXPhotos;

public class AlbumXPhotoDeleteCommand : DeleteCommand
{
    public Guid? AlbumId { get; set; }

    public Guid? PhotoId { get; set; }    
}