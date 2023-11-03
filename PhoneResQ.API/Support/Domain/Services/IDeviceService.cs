using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> ListAsync();
        Task<DeviceResponse> SaveAsync(Device device);
        Task<DeviceResponse> UpdateAsync(int id, Device device);
        Task<DeviceResponse> DeleteAsync(int id);
    }
}
