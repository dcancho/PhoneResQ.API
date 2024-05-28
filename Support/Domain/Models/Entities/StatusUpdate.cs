using PhoneResQ.API.Support.Domain.Models.ValueObjects;

namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class StatusUpdate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime UpdateTime { get; set; }
        public Order Order { get; set; }
        public Technician Technician { get; set; }
    }
}
