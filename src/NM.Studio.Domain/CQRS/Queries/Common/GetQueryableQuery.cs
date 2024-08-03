using NM.Studio.Domain.CQRS.Queries.Base;

namespace NM.Studio.Domain.CQRS.Queries.Common
{
    public class GetQueryableQuery : BaseQuery
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set;}
    }
}
