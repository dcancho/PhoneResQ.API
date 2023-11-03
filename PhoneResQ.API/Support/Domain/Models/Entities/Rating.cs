namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public Order Order { get; set; }
        public SupportCenter SupportCenter { get; set; }
    }
}
