using Logex.API.Models;

namespace Logex.API.Repository.Interfaces
{
    public interface IPricingRepository
    {
        /// <summary>
        /// Get the zone information for a given city name.
        /// </summary>
        Task<Zone?> GetZoneByCityNameAsync(string cityName);

        /// <summary>
        /// Get the rate between two zones.
        /// </summary>
        Task<ZoneRate?> GetRateByZonesAsync(int fromZoneId, int toZoneId);
    }
}
