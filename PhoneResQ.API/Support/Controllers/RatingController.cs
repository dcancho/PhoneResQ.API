using Microsoft.AspNetCore.Mvc;
using PhoneResQ.API.Shared.Infrastructure.Configuration.Extensions;
using PhoneResQ.API.Support.Domain.Models.Entities;
using PhoneResQ.API.Support.Domain.Services;
using PhoneResQ.API.Support.Resources;

namespace PhoneResQ.API.Support.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RatingController : ControllerBase
{
    private readonly IRatingService _ratingService;
    
    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var ratings = await _ratingService.ListAsync();
        var ratingResources = MapRatingsToRatingResources(ratings);
        return Ok(ratingResources);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRatingResource resource)
    {
        // Validación de los datos del recurso
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        // Crear un nuevo objeto Rating a partir de los datos del recurso
        var rating = new Rating
        {
            Score = resource.Score,
            Comment = resource.Comment,
            Order = new Order { Id = resource.AssociatedOrderId }
        };

        // Guardar la calificación (interacción con el servicio)
        var result = await _ratingService.SaveAsync(rating);

        // Si la operación no tiene éxito, devolver un mensaje de error
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        // Devolver el resultado exitoso
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRatingResource resource)
    {
        // Validation of the resource
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        var rating = new Rating
        {
            Score = resource.Score,
            Comment = resource.Comment
        };
        // Saving the rating (interaction with service)
        var result = await _ratingService.SaveAsync(rating);  // If the result is not successful, return the error message
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
        // Saving the rating (interaction with service)
        var result = await _ratingService.DeleteAsync(id);  // If the result is not successful, return the error message
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        // Returning the action result
        return Ok(result);
    }
    
    private RatingResource MapRatingToRatingResource(Rating rating)
    {
        var ratingResource = new RatingResource
        {
            Id = rating.Id,
            Score = rating.Score,
            Comment = rating.Comment,
        };
        return ratingResource;
    }
    
    private IEnumerable<RatingResource> MapRatingsToRatingResources(IEnumerable<Rating> ratings)
    {
        var ratingResources = new List<RatingResource>();
        foreach (var rating in ratings)
        {
            ratingResources.Add(MapRatingToRatingResource(rating));
        }
        return ratingResources;
    }
    
}