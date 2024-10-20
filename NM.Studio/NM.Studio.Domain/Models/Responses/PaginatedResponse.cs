using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Enums;

namespace NM.Studio.Domain.Models.Responses;

public class TableResponse<TResult> : MessageResponse where TResult : class
{
    public TableResponse(string message, GetQueryableQuery pagedQuery, List<TResult>? results, int? totalOrigin = null)
        : base(results != null, message)
    {
        PageNumber = totalOrigin != null ? pagedQuery.PageNumber : null;
        PageSize = totalOrigin != null ? pagedQuery.PageSize : null;
        SortField = pagedQuery.SortField;
        SortOrder = totalOrigin != null ? pagedQuery.SortOrder : null;
        Results = results;
        TotalRecords = totalOrigin ?? results?.Count;
        TotalRecordsPerPage = totalOrigin != null ? results?.Count : null;
        TotalPages = totalOrigin != null
            ? (int)Math.Ceiling((decimal)(totalOrigin / (double)pagedQuery.PageSize))
            : null;
    }

    public List<TResult>? Results { get; }

    public int? TotalPages { get; protected set; }

    public int? TotalRecordsPerPage { get; protected set; }

    public int? TotalRecords { get; protected set; }

    public int? PageNumber { get; protected set; }

    public int? PageSize { get; protected set; }

    public string? SortField { get; protected set; }

    public SortOrder? SortOrder { get; protected set; }
}