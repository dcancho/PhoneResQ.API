using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ITechnicianService
    {
        public Task<IEnumerable<Technician>> ListAsync();
        public Task<TechnicianResponse> SaveAsync(SaveTechnicianResource technician);
        public Task<TechnicianResponse> UpdateAsync(int id, SaveTechnicianResource technician);
        public Task<TechnicianResponse> DeleteAsync(int id);
        Task<IEnumerable<TechnicianResource>> ReadAsync();
        public Task<bool> LoginAsync(TechnicianLoginResource technician);
    }
}
