using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositorys;

public interface IActivityplacesRepository
{
    Task<IEnumerable<ActivityPlace>> GetAllAsync();

    Task<ActivityPlace?> GetByIdAsync(int id);

    Task<ActivityPlace> CreateAsync(ActivityPlace activityPlace);

    Task<bool> UpdateAsync(int id, ActivityPlace updatedActivityPlace);

    Task<bool> DeleteAsync(int id);
}
