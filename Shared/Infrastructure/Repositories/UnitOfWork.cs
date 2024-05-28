using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Shared.Infrastructure.Configuration;

namespace PhoneResQ.API.Shared.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
              _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
