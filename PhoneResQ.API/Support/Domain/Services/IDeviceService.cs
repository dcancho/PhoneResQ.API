using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IDeviceService
    {
        public Task<DeviceResponse> CreateAsync(Device device);
        public Task<DeviceResource> ReadAsync(int id);
        public Task<IEnumerable<Device>> ReadAsync();
        public Task<DeviceResponse> UpdateAsync(int id,SaveDeviceResource device);
        public Task<DeviceResponse> DeleteAsync(int id);
    }
}
