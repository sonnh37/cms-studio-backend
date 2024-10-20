﻿using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.CQRS.Queries.Albums;
using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.CQRS.Queries.Outfits.Categories;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Utilities.Filters;

namespace NM.Studio.Domain.Utilities;

public static class FilterHelper
{
    public static IQueryable<TEntity>? Apply<TEntity>(IQueryable<TEntity> queryable, GetQueryableQuery query)
        where TEntity : BaseEntity
    {
        return query switch
        {
            OutfitGetAllQuery outfitQuery =>
                Outfit(queryable as IQueryable<Outfit>, outfitQuery) as IQueryable<TEntity>,
            PhotoGetAllQuery photoQuery => Photo(queryable as IQueryable<Photo>, photoQuery) as IQueryable<TEntity>,
            ServiceGetAllQuery serviceQuery =>
                Service(queryable as IQueryable<Service>, serviceQuery) as IQueryable<TEntity>,
            AlbumGetAllQuery albumQuery => Album((queryable as IQueryable<Album>)!, albumQuery) as IQueryable<TEntity>,
            UserGetAllQuery userQuery => User(queryable as IQueryable<User>, userQuery) as IQueryable<TEntity>,
            CategoryGetAllQuery cateQuery =>
                Category((queryable as IQueryable<Category>)!, cateQuery) as IQueryable<TEntity>,
            _ => BaseFilterHelper.Base(queryable, query)
        };
    }

    private static IQueryable<Category> Category(IQueryable<Category> queryable, CategoryGetAllQuery query)
    {
        if (query.Name != null)
            queryable = queryable.Where(m => m.Name != null && m.Name.ToLower().Trim() == query.Name.ToLower().Trim());

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    private static IQueryable<Outfit>? Outfit(IQueryable<Outfit>? queryable, OutfitGetAllQuery query)
    {
        if (query.CategoryId != null) queryable = queryable.Where(m => m.CategoryId == query.CategoryId);
        
        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    private static IQueryable<Photo>? Photo(IQueryable<Photo>? queryable, PhotoGetAllQuery query)
    {
        queryable = BaseFilterHelper.Base(queryable, query);
        return queryable;
    }

    private static IQueryable<Service>? Service(IQueryable<Service>? queryable, ServiceGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Name))
        {
            var title = SlugHelper.FromSlug(query.Name.ToLower());
            queryable = queryable.Where(m => m.Name!.ToLower() == title);
        }
        
        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

    private static IQueryable<Album> Album(IQueryable<Album> queryable, AlbumGetAllQuery query)
    {
        if (!string.IsNullOrEmpty(query.Title))
        {
            var title = SlugHelper.FromSlug(query.Title.ToLower());
            queryable = queryable.Where(m => m.Title!.ToLower().Contains(title));
        }

        if (!string.IsNullOrEmpty(query.Description))
            queryable = queryable.Where(m => m.Description!.ToLower().Contains(query.Description.ToLower()));

        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
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
        
        queryable = BaseFilterHelper.Base(queryable, query);

        return queryable;
    }

}