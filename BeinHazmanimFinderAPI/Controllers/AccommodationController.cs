using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace BeinHazmanimFinderAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccommodationsController : ControllerBase
{

    private readonly IAccommodationsRepository _accommodationsRepository;

    public AccommodationsController(IAccommodationsRepository accommodationsRepository)
    {
        _accommodationsRepository = accommodationsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Accommodation>>> GetAllAccommodationsAsync()
    {
        var allAccommodations = await _accommodationsRepository.GetAllAsync();

        return Ok(allAccommodations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Accommodation>> GetAccommodationById(int id)// dos not end with asynk, asynk buters nameof in post
    {
        var accommodation = await _accommodationsRepository.GetByIdAsync(id);
        if (accommodation == null)
        {
            return NotFound();
        }

        return Ok(accommodation);
    }

    [HttpPost]
    public async Task<ActionResult<Accommodation>> PostAccommodatioAsync(Accommodation newAccommodation)
    {
        var createdAccommodation =await _accommodationsRepository.CreateAsync(newAccommodation);
        return CreatedAtAction(nameof(GetAccommodationById), new { id = createdAccommodation.Id }, createdAccommodation);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAccommodatioAsync(int id, Accommodation updatedAccommodation)
    {
        bool validId = await _accommodationsRepository.UpdateAsync(id, updatedAccommodation);

        if (!validId)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAccommodatioAsync(int id)
    {
        bool validId = await _accommodationsRepository.DeleteAsync(id);

        if (!validId)
        {
            return NotFound();
        }
        return NoContent();

    }
}
