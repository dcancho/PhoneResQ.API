using PhoneResQ.API.Shared.Infrastructure.Configuration;
using PhoneResQ.API.Shared.Infrastructure.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PhoneResQ.API.Support.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Customer?> FindByDNIAsync(string dni)
        {
            return _context.Customers.FirstOrDefaultAsync(c => c.DNI == dni);
        }
    }
}
