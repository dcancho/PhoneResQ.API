using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Repositories;

public interface ITechnicianRepository : IBaseRepository<Technician>
{
    Task<Technician?> FindByIdAsync(int id);
    Task<IEnumerable<Technician>> ListAsync();
    void Remove(Technician technician);
    void Update(Technician technician);
}