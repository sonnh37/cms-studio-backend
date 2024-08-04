using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM.Studio.Domain.CQRS.Commands.Outfits
{
    public class OutfitDeleteCommand : DeleteCommand<OutfitView>
    {
    }
}
