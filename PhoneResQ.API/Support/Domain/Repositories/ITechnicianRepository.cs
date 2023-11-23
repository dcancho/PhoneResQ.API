using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Repositories;

public interface ITechnicianRepository : IBaseRepository<Technician>
{
    public Task<Technician?> FindByTechnicianDniAsync(string dni);
}