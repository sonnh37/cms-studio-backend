using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Utilities;

public class AppMessage
{
    public static MessageResults<TResult> GetMessageResults<TResult>(List<TResult> results)
        where TResult : BaseResult
    {
        return new MessageResults<TResult>(results);
    }

    public static MessageResult<TResult> GetMessageResult<TResult>(TResult result)
        where TResult : BaseResult
    {
        return new MessageResult<TResult>(result);
    }

    public static MessageLoginResult<TResult> GetMessageLoginResult<TResult>(TResult result, string token,
        string expiration)
        where TResult : BaseResult
    {
        return new MessageLoginResult<TResult>(result, token, expiration);
    }

    public static MessageViews<TView> GetMessageViews<TView>(List<TView> views)
        where TView : BaseView
    {
        return new MessageViews<TView>(views);
    }

    public static MessageView<TView> GetMessageView<TView>(TView view)
        where TView : BaseView
    {
        return new MessageView<TView>(view);
    }
}