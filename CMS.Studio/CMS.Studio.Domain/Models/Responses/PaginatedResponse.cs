using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.Enums;

namespace CMS.Studio.Domain.Models.Responses;

public class PaginatedResponse<TResult> : MessageResponse where TResult : class
{
    public PaginatedResponse(string message, GetAllQuery pagedQuery, List<TResult>? results = null, int totalOrigin = 0)
        : base(results != null, message)
    {
        PageNumber = pagedQuery.PageNumber;
        PageSize = pagedQuery.PageSize;
        SortField = pagedQuery.SortField;
        SortOrder = pagedQuery.SortOrder;
        Results = results;
        TotalRecords = totalOrigin;
        TotalRecordsPerPage = results?.Count ?? 0;
        TotalPages = (int)Math.Ceiling(totalOrigin / (double)PageSize);
    }

    public List<TResult>? Results { get; }

    public int TotalPages { get; protected set; }

    public int TotalRecordsPerPage { get; protected set; }

    public int TotalRecords { get; protected set; }

    public int PageNumber { get; protected set; }

    public int PageSize { get; protected set; }

    public string? SortField { get; protected set; }

    public SortOrder? SortOrder { get; protected set; }
}