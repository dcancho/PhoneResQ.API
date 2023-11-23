using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class ReportResponse: BaseResponse<ReportResource>
    {
        public ReportResponse(ReportResource resource) : base(resource)
        {
        }

        public ReportResponse(string message) : base(message)
        {
        }
    }

}
