using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IStatusUpdateService
    {
        Task<IEnumerable<StatusUpdate>> ListAsync();
        Task<StatusUpdateResponse> SaveAsync(StatusUpdate statusUpdate);
        Task<StatusUpdateResponse> UpdateAsync(int id, StatusUpdate statusUpdate);
        Task<StatusUpdateResponse> DeleteAsync(int id);
    }
}
