using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Shared.Infrastructure.Configuration.Extensions;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Controllers
{
    [Route(template:"api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetAllAsync()
        {
            var customers = await _customerService.ReadAsync();
            return customers;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
        {
            // Validation of the resource
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // Saving the customer (interaction with service)
            var result = await _customerService.CreateAsync(resource);
            // If the result is not successful, return the error message
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            // Returning the action result
            return Ok(result);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
