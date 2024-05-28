using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class RatingResponse : BaseResponse<RatingResource>
    {
        public RatingResponse(RatingResource resource) : base(resource)
        {
        }

        public RatingResponse(string message) : base(message)
        {
        }
    }
}
