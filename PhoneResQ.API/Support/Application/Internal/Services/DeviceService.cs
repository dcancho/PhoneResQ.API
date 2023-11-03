using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Application.Internal.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeviceService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
        {
            _deviceRepository = deviceRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<DeviceResponse> DeleteAsync(int id)
        {
            var existingDevice = await _deviceRepository.FindByIdAsync(id);

            if (existingDevice == null)
                return new DeviceResponse("Device not found.");

            try
            {
                _deviceRepository.Remove(existingDevice);
                await unitOfWork.CompleteAsync();

                return new DeviceResponse(existingDevice);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DeviceResponse($"An error occurred when deleting the device: {ex.Message}");
            }
        }

        public Task<DeviceResource> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Device>> ListAsync()
        {
            return await _deviceRepository.ListAsync();
        }

        public async Task<DeviceResponse> SaveAsync(Device device)
        {
            var existingDevice = await _deviceRepository.FindByIdAsync(device.Id);
            if (existingDevice != null)
                return new DeviceResponse("Device already exists.");

            try
            {
                await _deviceRepository.AddAsync(device);
                await unitOfWork.CompleteAsync();

                return new DeviceResponse(device);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DeviceResponse($"An error occurred when saving the device: {ex.Message}");
            }   
        }
    }
}
