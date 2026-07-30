using BeinHazmanimFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeinHazmanimFinderAPI.Repositorys;

public class AccommodationsRepository:IAccommodationsRepository
{
    private readonly List<Accommodation> _accommodations;

    private int _nextId;

    public AccommodationsRepository()
    {
        _accommodations = new()
        {
            new Accommodation
            {

            }
        };
        _nextId = _accommodations.Count;
    }
    public async Task<IEnumerable<Accommodation>> GetAllAsync()
    {
        await Task.Delay(10);
        return _accommodations;
    }

    public async Task<Accommodation?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        return _accommodations.FirstOrDefault(a => a.Id ==id);
    }

    public async Task<Accommodation> CreateAsync(Accommodation accommodation)
    {
        await Task.Delay(10);
        accommodation.Id = _nextId++;
        _accommodations.Add(accommodation);
        return accommodation;
    }

    public async Task<bool> UpdateAsync(int id, Accommodation updatedAccommodation)
    {
        await Task.Delay(10);
        var oldAccommodation = await GetByIdAsync(id);

        if (oldAccommodation == null)
        {
            return false;
        }
        oldAccommodation.Name = updatedAccommodation.Name;
        oldAccommodation.AccommodationType = updatedAccommodation.AccommodationType;
        oldAccommodation.City = updatedAccommodation.City;
        oldAccommodation.Area = updatedAccommodation.Area;
        oldAccommodation.KashrutAuthority = updatedAccommodation.KashrutAuthority;
        oldAccommodation.PricePerNight = updatedAccommodation.PricePerNight;
        oldAccommodation.MaximumGuests = updatedAccommodation.MaximumGuests;
        oldAccommodation.AvailableFrom = updatedAccommodation.AvailableFrom;
        oldAccommodation.IsAccessible = updatedAccommodation.IsAccessible;
        oldAccommodation.IsAbroad= updatedAccommodation.IsAbroad;

        return true;    
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(10);
        var accommodation = await GetByIdAsync(id);

        if (accommodation == null)
        {
            return false;
        }

        _accommodations.Remove(accommodation);
        return true;
    }
}
