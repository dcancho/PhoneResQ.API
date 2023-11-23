using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeviceResponse> DeleteAsync(int id)
        {
            var existingDevice = await _deviceRepository.FindByIdAsync(id);

            if (existingDevice == null)
                return new DeviceResponse("Device not found.");

            try
            {
                _deviceRepository.Remove(existingDevice);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(_mapper.Map<DeviceResource>(existingDevice));
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DeviceResponse($"An error occurred when deleting the device: {ex.Message}");
            }
        }

        public Task<DeviceResource> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Device>> ReadAsync()
        {
            return await _deviceRepository.ListAsync();
        }

        public async Task<DeviceResponse> CreateAsync(Device device)
        {
            var existingDevice = await _deviceRepository.FindByIdAsync(device.Id);
            if (existingDevice != null)
                return new DeviceResponse("Device already exists.");

            try
            {
                await _deviceRepository.AddAsync(device);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(_mapper.Map<DeviceResource>(device));
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DeviceResponse($"An error occurred when saving the device: {ex.Message}");
            }   
        }

        public Task<DeviceResponse> UpdateAsync(int id, SaveDeviceResource device)
        {
            throw new NotImplementedException();
        }
    }
}
