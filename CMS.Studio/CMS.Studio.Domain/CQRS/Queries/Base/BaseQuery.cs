using CMS.Studio.Domain.Enums;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results.Bases;
using MediatR;

namespace CMS.Studio.Domain.CQRS.Queries.Base;

public abstract class BaseQuery
{
}

public class PaginationQuery : BaseQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortField { get; set; }
    public SortOrder? SortOrder { get; set; } 
}

public class CommonQueryableQuery : PaginationQuery
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}

public class BaseQueryableQuery : CommonQueryableQuery
{
    public Guid Id { get; set; }
    public string? CreatedBy { get; set; }
    public string? LastUpdatedBy { get; set; }
    public bool? IsDeleted { get; set; }
}

public class GetByIdQuery<TResult> : BaseQuery, IRequest<ItemResponse<TResult>> where TResult : BaseResult
{
    public Guid Id { get; set; }
}

public class GetAllQuery : BaseQueryableQuery
{
}

public class GetAllQuery<TResult> : GetAllQuery, IRequest<PaginatedResponse<TResult>>
    where TResult : BaseResult
{
}