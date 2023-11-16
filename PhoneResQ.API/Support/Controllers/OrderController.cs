using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Resources;
using PhoneResQ.API.Shared.Infrastructure.Configuration.Extensions;

namespace PhoneResQ.API.Support.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _orderService.ListAsync();
            var orderResources = MapOrdersToOrderResources(orders);
            return Ok(orderResources);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
        {
            // Validation of the resource
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var order = new Order
            {
                Description = resource.Description,
                Device = resource.Device,
                Customer = resource.Customer,
                Technician = resource.Technician,
                SupportCenter = resource.SupportCenter
            };
            // Saving the order (interaction with service)
            var result = await _orderService.SaveAsync(order);  // If the result is not successful, return the error message
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            // Returning the action result
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
        {
            // Validation of the resource
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var order = new Order
            {
                Description = resource.Description,
                Device = resource.Device,
                Customer = resource.Customer,
                Technician = resource.Technician,
                SupportCenter = resource.SupportCenter
            };
            // Saving the order (interaction with service)
            var result = await _orderService.UpdateAsync(id, order);  // If the result is not successful, return the error message
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            // Returning the action result
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _orderService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        
        private OrderResource MapOrderToOrderResource(Order order)
        {
            return new OrderResource
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Status = order.Status,
                Description = order.Description,
                Device = order.Device,
                Customer = order.Customer,
                Technician = order.Technician,
                SupportCenter = order.SupportCenter
            };
        }
        private List<OrderResource> MapOrdersToOrderResources(IEnumerable<Order> orders)
        {
            var orderResources = new List<OrderResource>();
            foreach (var order in orders)
            {
                orderResources.Add(MapOrderToOrderResource(order));
            }
            return orderResources;
        }

    }
}
