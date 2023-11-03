using PhoneResQ.API.Support.Domain.Models.ValueObjects;

namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ReportStatus Status { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
