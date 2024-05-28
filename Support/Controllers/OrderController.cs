using AutoMapper;
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
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        
        
        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<OrderResource>> GetAllAsync()
        {
            var orders = await _service.ReadAsync();
            return orders;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
        {
            // Validation of the resource
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // Create a new Order object from the resource data
            var order = new Order
            {
                Customer = resource.Customer,
                Device = resource.Device,
                Description = resource.Description,
                Technician = resource.Technician,
                SupportCenter = resource.SupportCenter,
            };

            // Map the Order object to a SaveOrderResource object
            var saveOrderResource = _mapper.Map<Order, SaveOrderResource>(order);

            // Save the order (interaction with the service)
            var result = await _service.SaveAsync(saveOrderResource);

            // If the operation is not successful, return an error message
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            // Return the successful result
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

            // Create a new Order object from the resource data
            var order = new Order
            {
                Id = id,
                Customer = resource.Customer,
                Device = resource.Device,
                Description = resource.Description,
                Technician = resource.Technician,
                SupportCenter = resource.SupportCenter,
            };

            // Map the Order object to a SaveOrderResource object
            var saveOrderResource = _mapper.Map<Order, SaveOrderResource>(order);

            // Save the order (interaction with the service)
            var result = await _service.SaveAsync(saveOrderResource);

            // If the operation is not successful, return an error message
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            // Return the successful result
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            // Saving the order (interaction with service)
            var result = await _service.DeleteAsync(id);  // If the result is not successful, return the error message
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            // Returning the action result
            return Ok(result);
        }

    }
}
