using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using NM.Studio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;

namespace NM.Studio.Data.Repositories;

public class OutfitXPhotoRepository : BaseRepository<OutfitXPhoto>, IOutfitXPhotoRepository
{
    public OutfitXPhotoRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public virtual async Task<OutfitXPhoto?> GetById(OutfitXPhotoDeleteCommand command)
    {
        var queryable = GetQueryable(x => x.OutfitId == command.OutfitId && x.PhotoId == command.PhotoId);
        var entity = await queryable.FirstOrDefaultAsync();

        return entity;
    }

    public new void Delete(OutfitXPhoto entity)
    {
        DbSet.Remove(entity);
    }
}