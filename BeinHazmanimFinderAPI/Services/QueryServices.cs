using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositorys;
using System.Security.AccessControl;

namespace BeinHazmanimFinderAPI.Services
{
    public class QueryServices:IQueryService
    {

        private readonly IAccommodationsRepository _accommodationsRepository;
        private readonly IActivityplacesRepository _activityplacesRepository;
        public QueryServices(
            IAccommodationsRepository accommodationsRepository,
            IActivityplacesRepository activityplacesRepository)
        {
            _accommodationsRepository = accommodationsRepository;
            _activityplacesRepository = activityplacesRepository;
        }
        public async Task<IEnumerable<Accommodation>> SearchAsync(
            string? city,
            decimal? maxPrice,
            bool? accessible)
        {
            var query =await _accommodationsRepository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(a => a.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(a => a.PricePerNight <= maxPrice.Value);
            }
            if (accessible.HasValue)
            {
                query = query.Where(a => a.IsAccessible == accessible.Value);
            }

            return await Task.FromResult(
                query
                    .OrderBy(a => a.PricePerNight)
                    .ThenBy(a => a.Name)
                    .ToList());
        }
        public async Task<IEnumerable<string>> GetTypesAsync()
        {
            var query = await _accommodationsRepository.GetAllAsync();

            return query.Select(a => a.AccommodationType).Distinct()
                        .OrderBy(t => t).ToList(); 
        }

        public async Task<IEnumerable<ActivityPlace>> GetAllActivitysAsync(
            string? category,
            string? city,
            decimal? maxPrice,
            string? audience)
        {

            var query = await _activityplacesRepository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(a => a.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(a => a.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(a => a.PricePerPerson <= maxPrice.Value);
            }
            if (!string.IsNullOrWhiteSpace(audience))
            {
                query = query.Where(a => a.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            return await Task.FromResult(query
                
                    .OrderBy(a => a.PricePerPerson)
                    .ThenBy(a => a.Name)
                    .ToList());
        }
    }
}
