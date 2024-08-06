using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;

namespace NM.Studio.Domain.CQRS.Commands.Services;

public class ServiceCreateCommand : CreateCommand<ServiceView>
{
    public string? Tittle { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Url { get; set; }
}