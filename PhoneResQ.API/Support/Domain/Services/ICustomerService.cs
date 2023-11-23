using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerResource>> ReadAsync();
        public Task<CustomerResponse> CreateAsync(SaveCustomerResource customer);
        public Task<CustomerResponse> UpdateAsync(int id, SaveCustomerResource customer);
        public Task<CustomerResponse> DeleteAsync(int id);
        public Task<bool> LoginAsync(CustomerLoginResource customer);
    }
}
