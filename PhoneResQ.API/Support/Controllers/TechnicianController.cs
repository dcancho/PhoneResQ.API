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
    private readonly ITechnicianService _technicianService;

    public TechnicianController(ITechnicianService technicianService)
    {
        _technicianService = technicianService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var technicians = await _technicianService.ListAsync();
        var technicianResources = MapTechniciansToTechnicianResources(technicians);
        return Ok(technicianResources);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTechnicianResource resource)
    {
        // Validation of the resource
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var technician = new Technician
        {
            Name = resource.Name,
            DNI = resource.DNI,
            Address = resource.Address,
            Password = resource.Password,
        };
        // Saving the technician (interaction with service)
        var result = await _technicianService.SaveAsync(technician);  // If the result is not successful, return the error message
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        // Returning the action result
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTechnicianResource resource)
    {
        // Validation of the resource
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var technician = new Technician
        {
            Name = resource.Name,
            DNI = resource.DNI,
            Address = resource.Address,
            Password = resource.Password,
        };
        // Saving the technician (interaction with service)
        var result = await _technicianService.UpdateAsync(id, technician);  // If the result is not successful, return the error message
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
        var result = await _technicianService.DeleteAsync(id);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }
    
    private static List<TechnicianResource> MapTechniciansToTechnicianResources(IEnumerable<Technician> technicians)
    {
        return technicians.Select(technician => new TechnicianResource
        {
            Id = technician.Id,
            Name = technician.Name,
            DNI = technician.DNI,
            Address = technician.Address,
            Password = technician.Password
        }).ToList();
    }
}