using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public long IMEI { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int OwnerId { get; set; }
        public Customer Owner { get; set; } = null!;
    }
}