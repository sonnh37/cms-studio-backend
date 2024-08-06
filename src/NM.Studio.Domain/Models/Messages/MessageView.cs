using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models.Messages;

public abstract class MessageView
{
    public long TotalRecords { get; set; }
    public bool IsSuccess { get; set; }
}

public class MessageView<TView> : MessageView where TView : BaseView
{
    public MessageView(TView view)
    {
        View = view;
        TotalRecords = view != null
            ? 1
            : 0;
        IsSuccess = view != null
            ? true
            : false;
    }

    public TView View { get; set; }
}

public class MessageViews<TView> : MessageView where TView : BaseView
{
    public MessageViews(IList<TView> views)
    {
        Views = views;
        TotalRecords = views != null && views.Count > 0
            ? views.Count
            : 0;
        IsSuccess = views != null
            ? true
            : false;
    }

    public IList<TView> Views { get; set; }
}