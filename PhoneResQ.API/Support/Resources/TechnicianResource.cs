using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Resources
{
    public class TechnicianResource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
    }

    public class SaveTechnicianResource
    {
        public string Name { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int SupportCenterId { get; set; }
    }

    public class TechnicianLoginResource
    {
        public string DNI { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
