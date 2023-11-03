using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ISupportCenterService
    {
        Task<IEnumerable<SupportCenter>> ListAsync();
        Task<SupportCenterResponse> SaveAsync(SupportCenter supportCenter);
        Task<SupportCenterResponse> UpdateAsync(int id, SupportCenter supportCenter);
        Task<SupportCenterResponse> DeleteAsync(int id);
    }
}
