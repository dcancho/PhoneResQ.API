using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Resources
{
    public class RatingResource
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }

    public class SaveRatingResource
    {
        public int Score { get; set; }
        public string Comment { get; set; }
        public int AssociatedOrderId { get; set; }
    }
}
