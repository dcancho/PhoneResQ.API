using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class TechnicianResponse : BaseResponse<TechnicianResource>
    {
        public TechnicianResponse(TechnicianResource resource) : base(resource)
        {
        }

        public TechnicianResponse(string message) : base(message)
        {
        }
    }
}
