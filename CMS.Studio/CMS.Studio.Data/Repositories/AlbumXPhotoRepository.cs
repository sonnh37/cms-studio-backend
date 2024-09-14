using AutoMapper;
using CMS.Studio.Data.Context;
using CMS.Studio.Data.Repositories.Base;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using CMS.Studio.Domain.CQRS.Queries.Albums;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Studio.Data.Repositories;

public class AlbumXPhotoRepository : BaseRepository<AlbumXPhoto>, IAlbumXPhotoRepository
{

    public AlbumXPhotoRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
    

    public virtual async Task<AlbumXPhoto?> GetById(AlbumXPhotoDeleteCommand command)
    {
        var queryable = GetQueryable(x => x.AlbumId == command.AlbumId && x.PhotoId == command.PhotoId);
        var entity = await queryable.FirstOrDefaultAsync();

        return entity;
    }
    
    public new void Delete(AlbumXPhoto entity)
    {
        DbSet.Remove(entity);
    }
}