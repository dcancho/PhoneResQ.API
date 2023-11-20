using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class OrderResponse : BaseResponse<Order>
    {
        public OrderResponse(Order resource) : base(resource)
        {
        }

        public OrderResponse(string message) : base(message)
        {
        }
    }
}
