using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class RatingResponse : BaseResponse<Rating>
    {
        public RatingResponse(Rating resource) : base(resource)
        {
        }

        public RatingResponse(string message) : base(message)
        {
        }
    }
}
