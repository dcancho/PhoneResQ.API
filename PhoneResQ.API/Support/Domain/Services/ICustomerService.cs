using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        Task<CustomerResponse> DeleteAsync(int id);
    }
}
