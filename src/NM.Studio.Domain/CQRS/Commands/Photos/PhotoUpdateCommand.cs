using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Photos
{
    public class PhotoUpdateCommand : UpdateCommand<PhotoView>
    {
        public string? Title { get; set; }
    
        public string? Description { get; set; }
    
        public string? Type { get; set; }

        public string? Src { get; set; }
    
        public string? Href { get; set; }
    }
}
