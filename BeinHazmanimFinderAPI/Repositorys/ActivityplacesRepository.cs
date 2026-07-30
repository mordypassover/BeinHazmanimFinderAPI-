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
        oldActivityPlace.AvailableAt = updatedActivityPlace.AvailableAt;
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
