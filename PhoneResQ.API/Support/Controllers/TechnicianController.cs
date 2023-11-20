using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Shared.Infrastructure.Configuration.Extensions;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Controllers;


[Route("api/v1/[controller]")]
[ApiController]
public class TechnicianController: ControllerBase
{
    private readonly ITechnicianService _service;
   
    public TechnicianController(ITechnicianService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TechnicianResource>> GetAllAsync()
    {
        var technicians = await _service.ReadAsync();
        return technicians;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTechnicianResource resource)
    {
        // Validation of the resource
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        // Saving the technician (interaction with service)
        var result = await _service.SaveAsync(resource);

        // If the result is not successful, return the error message
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        // Returning the action result
        return Ok(result);
    }
    
    // PUT api/<TechnicianController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }
    
    // DELETE api/<TechnicianController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}