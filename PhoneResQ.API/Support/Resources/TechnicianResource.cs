using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Resources
{
    public class TechnicianResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
    }

    public class SaveTechnicianResource
    {
        public string Name { get; set; }
        public string DNI { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int SupportCenterId { get; set; }
    }
}
