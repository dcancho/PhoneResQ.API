using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ISupportCenterService
    {
        public Task<IEnumerable<SupportCenter>> ListAsync();
        public Task<SupportCenterResponse> SaveAsync(SupportCenter supportCenter);
        public Task<SupportCenterResponse> UpdateAsync(int id, SupportCenter supportCenter);
        public Task<SupportCenterResponse> DeleteAsync(int id);
    }
}
