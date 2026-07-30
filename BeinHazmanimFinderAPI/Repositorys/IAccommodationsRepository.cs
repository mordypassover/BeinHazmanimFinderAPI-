using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositorys;

public interface IAccommodationsRepository
{
    Task<IEnumerable<Accommodation>> GetAllAsync();

    Task<Accommodation?> GetByIdAsync(int id );

    Task<Accommodation> CreateAsync( Accommodation accommodation );

    Task<bool> UpdateAsync(int id, Accommodation updatedAccommodation);

    Task<bool> DeleteAsync(int id);
}
