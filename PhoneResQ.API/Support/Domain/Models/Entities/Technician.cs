namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Technician
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? SupportCenterId { get; set; }
        public SupportCenter SupportCenter { get; set; } = null!;
    }
}
