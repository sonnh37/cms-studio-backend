using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models;

public class ServiceView : BaseView
{
    public string? Tittle { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Url { get; set; }
}