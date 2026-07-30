using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositorys;

public class ActivityplacesRepository : IActivityplacesRepository
{
    private readonly List<ActivityPlace> _activitys;

    private int _nextId;

    public ActivityplacesRepository()
    {
        _activitys = new()
        {
            new ActivityPlace
            {
                Id = 1,

                Name = "Cafe Rimon",

                Category = "Restaurant",

                City = "Jerusalem",

                Area = "City Center",

                TargetAudience = "Families",

                PricePerPerson = 90,

                MinimumAge = 0,

                AvailableDate = new DateTime(2026-08-01),

                IsAccessible = true,

                RequiresKashrut = true,

                KashrutAuthority = "Eida Charedit"
            },
            new ActivityPlace
            {
                Id = 2,

                Name = "Cafe Rimon",

                Category = "Restaurant",

                City = "Bnei Brak",

                Area = "Rabbi Akiva",

                TargetAudience = "Adults",

                PricePerPerson = 140,

                MinimumAge = 0,

                AvailableDate = new DateTime(2026-08-02),

                IsAccessible = false,

                RequiresKashrut = true,

                KashrutAuthority = "Rav Landau"
            },
            new ActivityPlace
            {
                Id = 2,

                Name = "Ein Gedi Nature Trail",

                Category = "Nature Trail",

                City = "Ein Ged",

                Area = "Dead Sea Basin",

                TargetAudience = "Families",

                PricePerPerson = 45,

                MinimumAge = 0,

                AvailableDate = new DateTime(2026-08-03),

                IsAccessible = false,

                RequiresKashrut = false,

                KashrutAuthority = null
            }

        };
        _nextId = _activitys.Count;
    }
    public async Task<IEnumerable<ActivityPlace>> GetAllAsync()
    {
        await Task.Delay(10);
        return _activitys;
    }

    public async Task<ActivityPlace?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        return _activitys.FirstOrDefault(a => a.Id == id);
    }

    public async Task<ActivityPlace> CreateAsync(ActivityPlace activityPlace)
    {
        await Task.Delay(10);
        activityPlace.Id = _nextId++;
        _activitys.Add(activityPlace);
        return activityPlace;
    }

    public async Task<bool> UpdateAsync(int id, ActivityPlace updatedActivityPlace)
    {
        await Task.Delay(10);
        var oldActivityPlace = await GetByIdAsync(id);

        if (oldActivityPlace == null)
        {
            return false;
        }
        oldActivityPlace.Name = updatedActivityPlace.Name;
        oldActivityPlace.Category = updatedActivityPlace.Category;
        oldActivityPlace.City = updatedActivityPlace.City;
        oldActivityPlace.Area = updatedActivityPlace.Area;
        oldActivityPlace.TargetAudience = updatedActivityPlace.TargetAudience;
        oldActivityPlace.PricePerPerson = updatedActivityPlace.PricePerPerson;
        oldActivityPlace.MinimumAge = updatedActivityPlace.MinimumAge;
        oldActivityPlace.AvailableDate = updatedActivityPlace.AvailableDate;
        oldActivityPlace.IsAccessible = updatedActivityPlace.IsAccessible;
        oldActivityPlace.RequiresKashrut = updatedActivityPlace.RequiresKashrut;
        oldActivityPlace.KashrutAuthority = updatedActivityPlace.KashrutAuthority;

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(10);
        var activityPlace = await GetByIdAsync(id);

        if (activityPlace == null)
        {
            return false;
        }

        _activitys.Remove(activityPlace);
        return true;
    }
}
