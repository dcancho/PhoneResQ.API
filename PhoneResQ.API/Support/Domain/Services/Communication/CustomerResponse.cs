using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse<CustomerResource>
    {
        public CustomerResponse(CustomerResource resource) : base(resource)
        {
        }

        public CustomerResponse(string message) : base(message)
        {
        }
    }
}
