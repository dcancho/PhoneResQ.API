using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Models.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PhoneResQ.API.Support.Resources
{
    public class NotificationResource
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public NotificationStatus StatusUpdate { get; set; }
    }

    public class SaveNotificationResource
    {
        [Required]
        [MaxLength(100)]
        public string Message { get; set; }
        [Required]
        public int RecipientId { get; set; }
    }
}
