using AutoMapper;
using CMS.Studio.Data.Context;
using CMS.Studio.Data.Repositories.Base;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.CQRS.Commands.OutfitXPhotos;
using CMS.Studio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Studio.Data.Repositories;

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