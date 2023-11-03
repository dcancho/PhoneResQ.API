using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse<Customer>
    {
        public CustomerResponse(Customer resource) : base(resource)
        {
        }

        public CustomerResponse(string message) : base(message)
        {
        }
    }
}
