using CMS.Studio.Domain.CQRS.Queries.Albums;
using CMS.Studio.Domain.CQRS.Queries.Base;
using CMS.Studio.Domain.CQRS.Queries.Outfits;
using CMS.Studio.Domain.CQRS.Queries.Outfits.Categories;
using CMS.Studio.Domain.CQRS.Queries.Photos;
using CMS.Studio.Domain.CQRS.Queries.Services;
using CMS.Studio.Domain.CQRS.Queries.Users;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore;
namespace CMS.Studio.Domain.Utilities;

public static class QueryFilterUtils
{
    public static IQueryable<TEntity>? Modify<TEntity>(IQueryable<TEntity>? queryable, GetQueryableQuery query)
        where TEntity : BaseEntity
    {
        return query switch
        {
            OutfitGetAllQuery outfitQuery =>
                Outfit(queryable as IQueryable<Outfit>, outfitQuery) as IQueryable<TEntity>,
            PhotoGetAllQuery photoQuery => Photo(queryable as IQueryable<Photo>, photoQuery) as IQueryable<TEntity>,
            ServiceGetAllQuery serviceQuery =>
                Service(queryable as IQueryable<Service>, serviceQuery) as IQueryable<TEntity>,
            AlbumGetAllQuery albumQuery => Album(queryable as IQueryable<Album>, albumQuery) as IQueryable<TEntity>,
            UserGetAllQuery userQuery => User(queryable as IQueryable<User>, userQuery) as IQueryable<TEntity>,
            CategoryGetAllQuery cateQuery =>
                Category(queryable as IQueryable<Category>, cateQuery) as IQueryable<TEntity>,
            _ => Base(queryable, query)
        };
    }

    private static IQueryable<Category>? Category(IQueryable<Category>? queryable, CategoryGetAllQuery query)
    {
        if (query.Name != null)
        {
            queryable = queryable.Where(m => m.Name != null && m.Name.ToLower().Trim() == query.Name.ToLower().Trim());
        }

        return Base(queryable, query);
    }

    private static IQueryable<Outfit>? Outfit(IQueryable<Outfit>? queryable, OutfitGetAllQuery query)
    {
        if (query.CategoryId != null)
        {
            queryable = queryable.Where(m => m.CategoryId == query.CategoryId);
        }
        queryable = queryable.AsNoTracking().Include(m => m.OutfitXPhotos).ThenInclude(m => m.Photo);
        return Base(queryable, query);
    }

    private static IQueryable<Photo>? Photo(IQueryable<Photo>? queryable, PhotoGetAllQuery query)
    {
        
        return Base(queryable, query);
    }

    private static IQueryable<Service>? Service(IQueryable<Service>? queryable, ServiceGetAllQuery query)
    {
        return Base(queryable, query);
    }

    private static IQueryable<Album>? Album(IQueryable<Album>? queryable, AlbumGetAllQuery query)
    {
        queryable = queryable.Include(m => m.AlbumXPhotos).ThenInclude(m => m.Photo);
        return Base(queryable, query);
    }

    private static IQueryable<User>? User(IQueryable<User>? queryable, UserGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Username))
            queryable = queryable.Where(e => e.Username.Contains(query.Username));

        if (!string.IsNullOrEmpty(query.FirstName))
            queryable = queryable.Where(e => e.FirstName.Contains(query.FirstName));

        if (!string.IsNullOrEmpty(query.LastName))
            queryable = queryable.Where(e => e.LastName.Contains(query.LastName));

        if (!string.IsNullOrEmpty(query.Email))
            queryable = queryable.Where(e => e.Email.Contains(query.Email));

        if (query.Dob.HasValue)
            queryable = queryable.Where(e => e.Dob == query.Dob);

        if (!string.IsNullOrEmpty(query.Address))
            queryable = queryable.Where(e => e.Address.Contains(query.Address));

        if (!string.IsNullOrEmpty(query.Role.ToString()))
            queryable = queryable.Where(e => e.Role == query.Role);

        if (!string.IsNullOrEmpty(query.Phone))
            queryable = queryable.Where(e => e.Phone.Contains(query.Phone));

        return Base(queryable, query);
    }

    private static IQueryable<TEntity>? FromDateToDate<TEntity>(IQueryable<TEntity>? queryable, GetQueryableQuery query)
        where TEntity : BaseEntity
    {
        if (query.FromDate.HasValue)
            queryable = queryable.Where(entity => entity.CreatedDate >= query.FromDate.Value);

        if (query.ToDate.HasValue)
            queryable = queryable.Where(entity => entity.CreatedDate <= query.ToDate.Value);

        return queryable;
    }

    private static IQueryable<TEntity>? Base<TEntity>(IQueryable<TEntity>? queryable, GetQueryableQuery query)
        where TEntity : BaseEntity
    {
        if (!string.IsNullOrEmpty(query.CreatedBy))
            queryable = queryable.Where(m => m.CreatedBy != null && m.CreatedBy.Contains(query.CreatedBy));

        if (!string.IsNullOrEmpty(query.LastUpdatedBy))
            queryable = queryable.Where(m =>
                query.LastUpdatedBy != null && m.LastUpdatedBy != null &&
                m.LastUpdatedBy.Contains(query.LastUpdatedBy));

        if (query.IsDeleted.HasValue)
            queryable = queryable.Where(m => m.IsDeleted == query.IsDeleted);

        queryable = FromDateToDate(queryable, query);

        return queryable;
    }
}