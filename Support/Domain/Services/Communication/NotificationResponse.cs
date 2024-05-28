using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class NotificationResponse : BaseResponse<NotificationResource>
    {
        public NotificationResponse(NotificationResource resource) : base(resource)
        {
        }

        public NotificationResponse(string message) : base(message)
        {
        }
    }
}
