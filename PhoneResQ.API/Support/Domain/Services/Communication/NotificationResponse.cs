using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class NotificationResponse : BaseResponse<Notification>
    {
        public NotificationResponse(Notification resource) : base(resource)
        {
        }

        public NotificationResponse(string message) : base(message)
        {
        }
    }
}
