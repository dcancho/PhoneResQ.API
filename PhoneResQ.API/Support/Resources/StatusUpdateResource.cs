using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Models.ValueObjects;

namespace PhoneResQ.API.Support.Resources
{
    public class StatusUpdateResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class SaveStatusUpdateResource
    {
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public int AssociatedOrderId { get; set; }
        public int TechnicianId { get; set; }
    }
}
