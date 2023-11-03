using PhoneResQ.API.Shared.Domain.Services.Communication;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Services.Communication
{
    public class ReportResponse: BaseResponse<Report>
    {
        public ReportResponse(Report resource) : base(resource)
        {
        }

        public ReportResponse(string message) : base(message)
        {
        }
    }

}
