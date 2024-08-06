using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models;

public class AlbumView : BaseView
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Background { get; set; }
}