using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class SupportCenterResponse: BaseResponse<SupportCenter>
    {
        public SupportCenterResponse(SupportCenter resource) : base(resource)
        {
        }

        public SupportCenterResponse(string message) : base(message)
        {
        }
    }
}
