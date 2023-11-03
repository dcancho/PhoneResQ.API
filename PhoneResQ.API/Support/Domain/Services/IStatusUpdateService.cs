using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IStatusUpdateService
    {
        public Task<IEnumerable<StatusUpdate>> ListAsync();
        public Task<StatusUpdateResponse> SaveAsync(StatusUpdate statusUpdate);
        public Task<StatusUpdateResponse> UpdateAsync(int id, StatusUpdate statusUpdate);
        public Task<StatusUpdateResponse> DeleteAsync(int id);
    }
}
