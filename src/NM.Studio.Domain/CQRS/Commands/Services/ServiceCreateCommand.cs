using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.CQRS.Commands.Services
{
    public class ServiceCreateCommand : CreateCommand<ServiceView>
    {
        public string ServiceTittle { get; set; }

        public string? ServiceDescription { get; set; }

        public string? Type { get; set; }

        public double Price { get; set; }

        public string? Status { get; set; }

        public Guid? Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
