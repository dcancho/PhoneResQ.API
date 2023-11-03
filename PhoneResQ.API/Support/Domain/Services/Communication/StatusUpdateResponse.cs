using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class StatusUpdateResponse: BaseResponse<StatusUpdate>
    {
        public StatusUpdateResponse(StatusUpdate resource) : base(resource)
        {
        }

        public StatusUpdateResponse(string message) : base(message)
        {
        }
    }
}
