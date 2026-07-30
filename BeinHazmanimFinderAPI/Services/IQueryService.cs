using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Services;

public interface IQueryService
{
    Task<IEnumerable<Accommodation>> SearchAsync(
        string? city, decimal? maxPrice, bool? accessible);

    Task<IEnumerable<string>> GetTypesAsync();


}