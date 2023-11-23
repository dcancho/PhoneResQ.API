using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Shared.Infrastructure.Configuration.Extensions;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Controllers;
[Route(template:"api/v1/[controller]")]
[ApiController]

public class DeviceController : ControllerBase
{
    private readonly IDeviceService _deviceService;
    
    public DeviceController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DeviceResource>> GetAllAsync()
    {
        var devices = await _deviceService.ReadAsync();
        var deviceResources = devices.Select(device => new DeviceResource
        {
            Id = device.Id,
            IMEI = device.IMEI,
            Brand = device.Brand,
            Model = device.Model
        });
        return deviceResources;
    }
    [HttpPost]
    [Route(template:"register-device")]
    public async Task<IActionResult> PostAsync([FromBody] SaveDeviceResource resource)
    {
        // Validation of the resource
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var device = new Device
        {
            IMEI = resource.IMEI,
            Brand = resource.Brand,
            Model = resource.Model,
            OwnerId = resource.OwnerId
        };
        // Saving the device (interaction with service)
        var result = await _deviceService.CreateAsync(device);  // If the result is not successful, return the error message
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        // Returning the action result
        return Ok(result);
    }
    
}