using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class StatusUpdateResponse: BaseResponse<StatusUpdateResource>
    {
        public StatusUpdateResponse(StatusUpdateResource resource) : base(resource)
        {
        }

        public StatusUpdateResponse(string message) : base(message)
        {
        }
    }
}
