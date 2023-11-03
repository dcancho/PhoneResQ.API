using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public Task<Customer?> FindByDNIAsync(string dni);
    }
}
