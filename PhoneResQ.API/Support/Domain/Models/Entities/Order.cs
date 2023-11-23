using PhoneResQ.API.Support.Domain.Models.ValueObjects;

namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public string Description { get; set; } = string.Empty;
        public Device Device { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public Technician Technician { get; set; } = null!;
        public SupportCenter SupportCenter { get; set; } = null!;
    }
}
