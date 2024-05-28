using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class DeviceResponse : BaseResponse<DeviceResource>
    {
        public DeviceResponse(DeviceResource resource) : base(resource)
        {
        }

        public DeviceResponse(string message) : base(message)
        {
        }
    }
}
