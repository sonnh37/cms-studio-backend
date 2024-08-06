using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Albums;

public class AlbumDeleteCommand : DeleteCommand<AlbumView>
{
}