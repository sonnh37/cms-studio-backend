using MediatR;
using NM.Studio.Domain.Enums;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Models.Results.Bases;

namespace NM.Studio.Domain.CQRS.Queries.Base;

public abstract class BaseQuery
{
}

public class GetPaginationQuery : BaseQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortField { get; set; }
    public SortOrder? SortOrder { get; set; } = Enums.SortOrder.Ascending;
}

public class GetQueryableQuery : GetPaginationQuery
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

    public Guid Id { get; set; }
    public string? CreatedBy { get; set; }
    public string? LastUpdatedBy { get; set; }
    public bool? IsDeleted { get; set; }

    public bool IsPagination { get; set; }
}

public class GetByIdQuery<TResult> : BaseQuery, IRequest<ItemResponse<TResult>> where TResult : BaseResult
{
    public Guid Id { get; set; }
}

public class GetAllQuery<TResult> : GetQueryableQuery, IRequest<TableResponse<TResult>>
    where TResult : BaseResult
{
}