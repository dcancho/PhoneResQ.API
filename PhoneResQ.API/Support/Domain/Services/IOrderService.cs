using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services.Communication;

namespace PhoneResQ.API.Support.Domain.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> ListAsync();
        public Task<OrderResponse> SaveAsync(Order order);
        public Task<OrderResponse> UpdateAsync(int id, Order order);
        public Task<OrderResponse> DeleteAsync(int id);
    }
}
