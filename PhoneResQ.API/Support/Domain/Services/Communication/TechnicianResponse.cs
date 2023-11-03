using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class TechnicianResponse : BaseResponse<Technician>
    {
        public TechnicianResponse(Technician resource) : base(resource)
        {
        }

        public TechnicianResponse(string message) : base(message)
        {
        }
    }
}
