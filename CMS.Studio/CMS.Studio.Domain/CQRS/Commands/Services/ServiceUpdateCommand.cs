using CMS.Studio.Domain.CQRS.Commands.Base;

namespace CMS.Studio.Domain.CQRS.Commands.Services;

public class ServiceUpdateCommand : UpdateCommand
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Src { get; set; }
}