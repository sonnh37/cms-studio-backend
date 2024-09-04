using AutoMapper;
using CMS.Studio.Data.Context;
using CMS.Studio.Data.Repositories.Base;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.CQRS.Queries.Albums;
using CMS.Studio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Studio.Data.Repositories;

public class AlbumXPhotoRepository : BaseRepository<AlbumXPhoto>, IAlbumXPhotoRepository
{

    public AlbumXPhotoRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

}