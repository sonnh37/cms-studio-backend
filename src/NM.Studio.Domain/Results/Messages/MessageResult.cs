using NM.Studio.Domain.Results.Bases;

namespace NM.Studio.Domain.Results.Messages
{
    public abstract class MessageResult
    {
        public long TotalRecords { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class MessageResult<TResult> : MessageResult where TResult : BaseResult
    {
        public TResult Result { get; set; }

        public MessageResult(TResult result)
        {
            Result = result;
            TotalRecords = (result != null)
                ? 1 : 0;
            IsSuccess = (result != null)
                ? true : false;
        }

    }

    public class MessageResults<TResult> : MessageResult where TResult: BaseResult
    {
        public IList<TResult> Results { get; set; }
        public MessageResults(IList<TResult> results)
        {
            Results = results;
            TotalRecords = (results != null && results.Count > 0) 
                ? results.Count : 0;
            IsSuccess = (results != null)
                ? true : false;
        }
    }

    public class MessageLoginResult<TResult> : MessageResult where TResult : BaseResult
    {
        public TResult Result { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }


        public MessageLoginResult(TResult result, string token, string expiration)
        {
            Result = result;
            Token = token;
            Expiration = expiration;
            TotalRecords = (result != null)
                ? 1 : 0;
            IsSuccess = (result != null)
                ? true : false;
        }

    }
}
