using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IReportService
    {
        public Task<IEnumerable<Report>> ListAsync();
        public Task<ReportResponse> SaveAsync(Report report);
        public Task<ReportResponse> UpdateAsync(int id, Report report);
        public Task<ReportResponse> DeleteAsync(int id);
    }
}
