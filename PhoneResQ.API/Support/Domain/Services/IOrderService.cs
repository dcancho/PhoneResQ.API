using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> ListAsync();
        public Task<OrderResponse> SaveAsync(SaveOrderResource order);
        public Task<OrderResponse> UpdateAsync(int id, Order order);
        public Task<OrderResponse> DeleteAsync(int id);
        Task<IEnumerable<OrderResource>> ReadAsync();
    }
}
