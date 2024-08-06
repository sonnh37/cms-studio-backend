using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Albums;

public class AlbumUpdateCommand : UpdateCommand<AlbumView>
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Background { get; set; }
}