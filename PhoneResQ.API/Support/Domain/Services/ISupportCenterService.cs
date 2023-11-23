using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ISupportCenterService
    {
        public Task<IEnumerable<SupportCenter>> ListAsync();
        public Task<SupportCenterResponse> SaveAsync(SaveSupportCenterResource supportCenter);
        public Task<SupportCenterResponse> UpdateAsync(int id, SupportCenter supportCenter);
        public Task<SupportCenterResponse> DeleteAsync(int id);
    }
}
