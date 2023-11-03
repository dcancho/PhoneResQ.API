using PhoneResQ.API.Support.Domain.Models.ValueObjects;

namespace PhoneResQ.API.Support.Domain.Models.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public NotificationStatus StatusUpdate { get; set; }
        public Customer Recipient { get; set; }
    }
}
