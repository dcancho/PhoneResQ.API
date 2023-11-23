namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Technician
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int? SupportCenterId { get; set; }
        public SupportCenter SupportCenter { get; set; } = null!;
    }
}
