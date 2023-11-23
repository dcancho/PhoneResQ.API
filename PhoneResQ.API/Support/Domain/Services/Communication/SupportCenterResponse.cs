using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class SupportCenterResponse: BaseResponse<SupportCenterResource>
    {
        public SupportCenterResponse(SupportCenterResource resource) : base(resource)
        {
        }

        public SupportCenterResponse(string message) : base(message)
        {
        }
    }
}
