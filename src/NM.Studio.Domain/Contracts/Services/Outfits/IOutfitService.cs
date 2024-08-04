using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NM.Studio.Domain.CQRS.Queries.Outfits;

namespace NM.Studio.Domain.Contracts.Services.Outfits
{
    public interface IOutfitService : IBaseService
    {
        Task<MessageResults<OutfitResult>> GetAll(OutfitGetAllQuery x, CancellationToken cancellationToken = default);
    }
}
