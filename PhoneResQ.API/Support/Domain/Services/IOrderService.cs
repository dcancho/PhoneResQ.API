using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<OrderResponse> SaveAsync(Order order);
        Task<OrderResponse> UpdateAsync(int id, Order order);
        Task<OrderResponse> DeleteAsync(int id);
    }
}
