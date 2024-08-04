using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Photos
{
    public class PhotoCreateCommand : CreateCommand<PhotoView>
    {
        public string? Name { get; set; }

        public string? Url { get; set; }
    }
}
