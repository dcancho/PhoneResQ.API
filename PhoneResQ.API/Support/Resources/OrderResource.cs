using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Models.ValueObjects;

namespace PhoneResQ.API.Support.Resources
{
    public class OrderResource
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public string Description { get; set; }
        public Device Device { get; set; }
        public Customer Customer { get; set; }
        public Technician Technician { get; set; }
        public SupportCenter SupportCenter { get; set; }
    }
    public class SaveOrderResource
    {
        public string Description { get; set; }
        public Device Device { get; set; }
        public Customer Customer { get; set; }
        public Technician Technician { get; set; }
        public SupportCenter SupportCenter { get; set; }
        
    }
}
