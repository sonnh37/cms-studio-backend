using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Photos;

public class PhotoCreateCommand : CreateCommand<PhotoView>
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }

    public string? Href { get; set; }
    
    public Guid? AlbumId { get; set; }
    
    public Guid? OutfitId { get; set; }

}