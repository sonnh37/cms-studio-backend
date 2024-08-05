using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models;

public class PhotoView : BaseView
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Type { get; set; }

    public string? Src { get; set; }
    
    public string? Href { get; set; }

}