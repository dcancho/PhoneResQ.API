using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Models.ValueObjects;

namespace PhoneResQ.API.Support.Resources
{
    public class ReportResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ReportStatus Status { get; set; }
    }

    public class SaveReportResource
    {
        public string Description { get; set; }
        public ReportStatus Status { get; set; }
        public int AssociatedOrderId { get; set; }
        public int CustomerId { get; set; }
    }
}
