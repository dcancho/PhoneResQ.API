using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ITechnicianService
    {
        Task<IEnumerable<Technician>> ListAsync();
        Task<TechnicianResponse> SaveAsync(Technician technician);
        Task<TechnicianResponse> UpdateAsync(int id, Technician technician);
        Task<TechnicianResponse> DeleteAsync(int id);
    }
}
