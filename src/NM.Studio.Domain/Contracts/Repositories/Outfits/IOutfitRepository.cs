using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Queries.Outfits;
using NM.Studio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM.Studio.Domain.Contracts.Repositories.Outfits
{
    public interface IOutfitRepository : IBaseRepository
    {
        Task<IList<Outfit>> GetAllWithInclude(OutfitGetAllQuery query, CancellationToken cancellationToken = default);
    }
}
