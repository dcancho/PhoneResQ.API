using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> ListAsync();
        Task<ReportResponse> SaveAsync(Report report);
        Task<ReportResponse> UpdateAsync(int id, Report report);
        Task<ReportResponse> DeleteAsync(int id);
    }
}
