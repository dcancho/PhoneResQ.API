using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IDeviceService
    {
        public Task<DeviceResource> FindById(int id);
        public Task<IEnumerable<Device>> ListAsync();
        public Task<DeviceResponse> UpdateAsync(Device device);
        public Task<DeviceResponse> DeleteAsync(int id);
    }
}
