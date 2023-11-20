using Microsoft.EntityFrameworkCore;
using PhoneResQ.API.Shared.Infrastructure.Configuration;
using PhoneResQ.API.Shared.Infrastructure.Repositories;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Repositories;

namespace PhoneResQ.API.Support.Infrastructure.Repositories;

public class OrderRepository: BaseRepository<Order>, IOrderRepository

{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
    
    public Task<Order?> FindByCustomerAsync(Customer customer)
    {
        return _context.Orders.FirstOrDefaultAsync(o => o.Customer == customer);
    }
    
}