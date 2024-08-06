using MediatR;
using NM.Studio.Domain.CQRS.Queries.Common;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.CQRS.Queries.Base;

public abstract class BaseQuery
{
}

public class GetAllQuery<TResult> : GetQueryableQuery, IRequest<MessageResults<TResult>> where TResult : BaseResult
{
}

public class GetByIdQuery<TResult> : GetQueryableQuery, IRequest<MessageResult<TResult>> where TResult : BaseResult
{
    public Guid Id { get; set; }
    //public GetByIdQuery()
    //{

    //}
    //public GetByIdQuery(Guid id) : this()
    //{
    //    Id = id;
    //}
}