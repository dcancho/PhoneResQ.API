using AutoMapper;
using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Infrastructure.Repositories;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Application.Internal.Services;

public class TechnicianService : ITechnicianService
{
    private readonly ITechnicianRepository _technicianRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ISupportCenterRepository _supportCenterRepository;

    
    public TechnicianService(ITechnicianRepository technicianRepository, ISupportCenterRepository supportCenterRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _technicianRepository = technicianRepository;
        _supportCenterRepository = supportCenterRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TechnicianResource>> ReadAsync()
    {
        var technicians = await _technicianRepository.ListAsync();
        var resources = _mapper.Map<IEnumerable<Technician>, IEnumerable<TechnicianResource>>(technicians);
        return resources;
    }
    
    public async Task<TechnicianResponse> SaveAsync(SaveTechnicianResource technician)
    {
        if (technician == null)
        {
            return new TechnicianResponse("Technician is null.");
        }

        Technician newTechnician;
        try
        {
            var existingTechnician = await _technicianRepository.FindByTechnicianDniAsync(technician.DNI);
            if (existingTechnician != null)
                return new TechnicianResponse("Technician already exists.");

            newTechnician = _mapper.Map<SaveTechnicianResource, Technician>(technician);
        }
        catch (Exception ex)
        {
            return new TechnicianResponse($"An error occurred when processing the technician: {ex.Message}");
        }

        try
        {
            await _technicianRepository.AddAsync(newTechnician);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            return new TechnicianResponse($"An error occurred when saving the technician: {ex.Message}");
        }

        return new TechnicianResponse(_mapper.Map<Technician, TechnicianResource>(newTechnician));
    }
    
    public async Task<TechnicianResponse> UpdateAsync(int id, SaveTechnicianResource technician)
    {
        var existingTechnician = await _technicianRepository.FindByIdAsync(id);

        if (existingTechnician == null)
            return new TechnicianResponse("Technician not found.");

        var supportCenter = await _supportCenterRepository.FindByIdAsync(technician.SupportCenterId);
        if (supportCenter == null)
            return new TechnicianResponse("Support center not found.");


        existingTechnician.DNI = technician.DNI;
        existingTechnician.Name = technician.Name;
        existingTechnician.Address = technician.Address;
        existingTechnician.Password = technician.Password;
        existingTechnician.SupportCenter = supportCenter;

        try
        {
            _technicianRepository.Update(existingTechnician);
            await _unitOfWork.CompleteAsync();

            return new TechnicianResponse(_mapper.Map<Technician, TechnicianResource>(existingTechnician));
        }
        catch (Exception ex)
        {
            return new TechnicianResponse($"An error occurred when updating the technician: {ex.Message}");
        }
    }

    public async Task<TechnicianResponse> DeleteAsync(int id)
    {
        var existingTechnician = await _technicianRepository.FindByIdAsync(id);

        if (existingTechnician == null)
            return new TechnicianResponse("Technician not found.");

        try
        {
            _technicianRepository.Remove(existingTechnician);
            await _unitOfWork.CompleteAsync();

            return new TechnicianResponse(_mapper.Map<Technician, TechnicianResource>(existingTechnician));
        }
        catch (Exception ex)
        {
            return new TechnicianResponse($"An error occurred when deleting the technician: {ex.Message}");
        }
    }
    
    public async Task<IEnumerable<Technician>> ListAsync()
    {
        return await _technicianRepository.ListAsync();
    }

    public async Task<bool> LoginAsync(TechnicianLoginResource technician)
    {
        var existingTechnician = await _technicianRepository.FindByTechnicianDniAsync(technician.DNI);
        if (existingTechnician != null)
        {
            if (existingTechnician.Password == technician.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
            // throw new Exception("Customer not found.");
        }
    }
}