using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositorys;
using BeinHazmanimFinderAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeinHazmanimFinderAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityplacesController : ControllerBase
{
    private readonly IActivityplacesRepository _activityplacesRepository;
    private readonly IQueryService _queryService;

    public ActivityplacesController(IActivityplacesRepository activityplacesRepository, IQueryService queryService)
    {
        _activityplacesRepository = activityplacesRepository;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityPlace>>> GetAllActivityPlacesAsync()
    {
        var allActivityPlaces = await _activityplacesRepository.GetAllAsync();

        return Ok(allActivityPlaces);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityPlace>> GetActivityPlaceById(int id)// dos not end with asynk, asynk buters nameof in post  
    {
        var activityPlace = await _activityplacesRepository.GetByIdAsync(id);
        if (activityPlace == null)
        {
            return NotFound();
        }

        return Ok(activityPlace);
    }

    [HttpPost]
    public async Task<ActionResult<ActivityPlace>> PostAccommodatioAsync(ActivityPlace newActivityPlace)
    {
        newActivityPlace = await _activityplacesRepository.CreateAsync(newActivityPlace);
        return CreatedAtAction(nameof(GetActivityPlaceById), new { id = newActivityPlace.Id }, newActivityPlace);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateActivityPlaceAsync(int id, ActivityPlace updatedActivityPlace)
    {
        bool validId = await _activityplacesRepository.UpdateAsync(id, updatedActivityPlace);

        if (!validId)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivityPlace(int id)
    {
        bool validId = await _activityplacesRepository.DeleteAsync(id);

        if (!validId)
        {
            return NotFound();
        }
        return NoContent();

    }
    [HttpGet("search/")]
    public async Task<ActionResult<IEnumerable<Accommodation>>> SearchAccommodatiAsync([FromQuery] string? category, [FromQuery] string? city,
                                             [FromQuery] decimal? maxPrice, [FromQuery] string? audience)
    {
        var responce = await _queryService.GetAllActivitysAsync(category, city, maxPrice, audience);

        return Ok(responce);
        
    }
}

