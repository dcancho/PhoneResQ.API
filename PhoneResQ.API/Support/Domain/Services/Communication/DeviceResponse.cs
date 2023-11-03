using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class DeviceResponse : BaseResponse<Device>
    {
        public DeviceResponse(Device resource) : base(resource)
        {
        }

        public DeviceResponse(string message) : base(message)
        {
        }
    }
}
