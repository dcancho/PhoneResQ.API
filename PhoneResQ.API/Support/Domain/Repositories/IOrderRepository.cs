using PhoneResQ.API.Shared.Domain.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    public Task<Order?> FindByCustomerAsync(Customer customer);
}