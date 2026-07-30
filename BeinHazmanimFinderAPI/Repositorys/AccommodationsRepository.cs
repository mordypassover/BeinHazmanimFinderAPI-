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
                Id = 1,

                Name = "King David Suites",

                AccommodationType = "Hotel",

                City ="Jerusalem",

                Area = "City Center",

                KashrutAuthority = "Eida Charedit",

                PricePerNight = 950,

                MaximumGuests = 4,

                AvailableFrom = new DateTime(2026-08-01),

                IsAccessible = true,

                IsAbroad = false

            },
            new Accommodation
            {
                Id = 2,

                Name = "Ramat Shlomo Apartment",

                AccommodationType = "Vacation Apartment",

                City ="Jerusalem",

                Area = "Ramat Shlomo",

                KashrutAuthority = "Eida Charedit",

                PricePerNight = 520,

                MaximumGuests = 6,

                AvailableFrom = new DateTime(2026-08-02),

                IsAccessible = false,

                IsAbroad = false
            },
            new Accommodation
            {
                Id = 3,

                Name = "Rabbi Akiva Guest House",

                AccommodationType = "Guest House",

                City ="Bnei Brak",

                Area = "Rabbi Akiva",

                KashrutAuthority = "Rav Landau",

                PricePerNight = 430,

                MaximumGuests = 8,

                AvailableFrom = new DateTime(2026-08-03),

                IsAccessible = true,

                IsAbroad = false
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
