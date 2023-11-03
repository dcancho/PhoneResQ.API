using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ITechnicianService
    {
        public Task<IEnumerable<Technician>> ListAsync();
        public Task<TechnicianResponse> SaveAsync(Technician technician);
        public Task<TechnicianResponse> UpdateAsync(int id, Technician technician);
        public Task<TechnicianResponse> DeleteAsync(int id);
    }
}
