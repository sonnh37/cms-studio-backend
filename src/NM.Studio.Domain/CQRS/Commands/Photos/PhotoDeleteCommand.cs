using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Photos;

public class PhotoDeleteCommand : DeleteCommand<PhotoView>
{
}