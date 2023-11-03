namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public long IMEI { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Customer Owner { get; set; }
    }
}
