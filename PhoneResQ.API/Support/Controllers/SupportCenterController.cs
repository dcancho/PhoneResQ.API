using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Shared.Infrastructure.Configuration.Extensions;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class SupportCenterController : ControllerBase
{
    private readonly ISupportCenterService _supportCenterService;
    
    public SupportCenterController(ISupportCenterService supportCenterService)
    {
        _supportCenterService = supportCenterService;
    }
    
    [HttpGet]
    
    public async Task<IActionResult> GetAllAsync()
    {
        var supportCenters = await _supportCenterService.ListAsync();
        var supportCenterResources = MapSupportCentersToSupportCenterResources(supportCenters);
        return Ok(supportCenterResources);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSupportCenterResource resource)
    {
        // Validation of the resource
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var supportCenter = new SupportCenter
        {
            Name = resource.Name,
            RUC = resource.RUC,
            Address = resource.Address,
        };
        // Saving the supportCenter (interaction with service)
        var result = await _supportCenterService.SaveAsync(supportCenter);  // If the result is not successful, return the error message
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        // Returning the action result
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSupportCenterResource resource)
    {
        // Validation of the resource
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var supportCenter = new SupportCenter
        {
            Name = resource.Name,
            RUC = resource.RUC,
            Address = resource.Address,
        };
        // Saving the supportCenter (interaction with service)
        var result = await _supportCenterService.UpdateAsync(id, supportCenter);  // If the result is not successful, return the error message
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
        var result = await _supportCenterService.DeleteAsync(id);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }
    
    private List<SupportCenterResource> MapSupportCentersToSupportCenterResources(List<SupportCenter> supportCenters)
    {
        var supportCenterResources = new List<SupportCenterResource>();
        foreach (var supportCenter in supportCenters)
        {
            supportCenterResources.Add(new SupportCenterResource
            {
                Id = supportCenter.Id,
                Name = supportCenter.Name,
                RUC = supportCenter.RUC,
                Address = supportCenter.Address,
            });
        }
        return supportCenterResources;
    }
    
    private SupportCenterResource MapSupportCenterToSupportCenterResource(SupportCenter supportCenter)
    {
        return new SupportCenterResource
        {
            Id = supportCenter.Id,
            Name = supportCenter.Name,
            RUC = supportCenter.RUC,
            Address = supportCenter.Address,
        };
    }
    
    private static List<SupportCenterResource> MapSupportCentersToSupportCenterResources(IEnumerable<SupportCenter> supportCenters)
    {
        return supportCenters.Select(supportCenter => new SupportCenterResource
        {
            Id = supportCenter.Id,
            Name = supportCenter.Name,
            RUC = supportCenter.RUC,
            Address = supportCenter.Address,
        }).ToList();
    }
    
    
}