namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class SupportCenter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RUC { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
