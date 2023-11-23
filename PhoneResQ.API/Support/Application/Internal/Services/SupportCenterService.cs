using AutoMapper;
using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Application.Internal.Services
{
    public class SupportCenterService : ISupportCenterService
    {
        private readonly ISupportCenterRepository _supportCenterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public SupportCenterService(ISupportCenterRepository supportCenterRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _supportCenterRepository = supportCenterRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<SupportCenterResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupportCenter>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SupportCenterResponse> SaveAsync(SaveSupportCenterResource supportCenter)
        {
            var existsSupportCenter = await _supportCenterRepository.FindByRUCAsync(supportCenter.RUC);
            if (existsSupportCenter == true)
                return new SupportCenterResponse("Support Center already exists.");

            var supportCenterEntity = _mapper.Map<SupportCenter>(supportCenter);

            try
            {
                await _supportCenterRepository.AddAsync(supportCenterEntity);
                await _unitOfWork.CompleteAsync();

                var supportCenterResource = _mapper.Map<SupportCenterResource>(supportCenterEntity);

                return new SupportCenterResponse(supportCenterResource);
            }
            catch (Exception ex)
            {
                return new SupportCenterResponse($"An error occurred when saving the support center: {ex.Message}");
            }

        }

        public Task<SupportCenterResponse> UpdateAsync(int id, SupportCenter supportCenter)
        {
            throw new NotImplementedException();
        }
    }
}