using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM.Studio.Domain.CQRS.Commands.Outfits
{
    public class OutfitCreateCommand : CreateCommand<OutfitView>
    {
        public string? Type { get; set; }

        public string? Name { get; set; }

        public string? Size { get; set; }

        public decimal? Price { get; set; }

        public string? Color { get; set; }

        public string? Description { get; set; }
    }
}
