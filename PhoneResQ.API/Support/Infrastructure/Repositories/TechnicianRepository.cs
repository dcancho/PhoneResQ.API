using Microsoft.EntityFrameworkCore;
using PhoneResQ.API.Shared.Infrastructure.Configuration;
using PhoneResQ.API.Shared.Infrastructure.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;

namespace PhoneResQ.API.Support.Infrastructure.Repositories;

public class TechnicianRepository : BaseRepository<Technician>, ITechnicianRepository
{
    public TechnicianRepository(AppDbContext context) : base(context)
    {
        
    }
    
    public Task<Technician?> FindByTechnicianDniAsync(string dni)
    {
        return _context.Technicians.FirstOrDefaultAsync(t => t.DNI == dni);
    }

    
    
}