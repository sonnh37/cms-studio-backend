using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.CQRS.Commands.AlbumXPhotos;
using NM.Studio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;

namespace NM.Studio.Data.Repositories;

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