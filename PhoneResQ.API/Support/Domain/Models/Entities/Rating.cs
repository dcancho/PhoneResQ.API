namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Order Order { get; set; } = null!;
        public SupportCenter SupportCenter { get; set; } = null!;
    }
}
