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

public static class IncludeHelper
{
    public static IQueryable<TEntity> Modify<TEntity>(IQueryable<TEntity> queryable)
        where TEntity : BaseEntity
    {
        return (queryable switch
        {
            IQueryable<Album> albums => Album(albums) as IQueryable<TEntity> ,
            IQueryable<Outfit> outfits => Outfit(outfits) as IQueryable<TEntity> ,
            IQueryable<Service> services => Service(services) as IQueryable<TEntity> ,
            IQueryable<Photo> photos => Photo(photos) as IQueryable<TEntity> ,
            _ => queryable
        })!;
    }
    
    private static IQueryable<Album> Album(IQueryable<Album> queryable)
    {
        queryable = queryable.AsNoTracking()
            .Include(m => m.AlbumXPhotos).ThenInclude(m => m.Photo);

        return queryable;
    }
    
    private static IQueryable<Outfit> Outfit(IQueryable<Outfit> queryable)
    {
        queryable = queryable.AsNoTracking()
            .Include( m=> m.Size)
            .Include( m=> m.Category)
            .Include( m=> m.Color)
            .Include(m => m.OutfitXPhotos).ThenInclude(m => m.Photo);

        return queryable;
    }
    
    private static IQueryable<Service> Service(IQueryable<Service> queryable)
    {
        queryable = queryable.AsNoTracking();

        return queryable;
    }
    
    private static IQueryable<Photo> Photo(IQueryable<Photo> queryable)
    {
        queryable = queryable.AsNoTracking()
            .Include(m => m.OutfitXPhotos).ThenInclude(m => m.Outfit)
            .Include(m => m.AlbumsXPhotos).ThenInclude(m => m.Album);

        return queryable;
    }
}