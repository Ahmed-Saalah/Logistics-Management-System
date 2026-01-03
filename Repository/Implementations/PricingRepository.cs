using Logex.API.Data;
using Logex.API.Models;
using Logex.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logex.API.Repository.Implementations
{
    public class PricingRepository : IPricingRepository
    {
        private readonly AppDbContext _context;

        public PricingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Zone?> GetZoneByCityNameAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return null;
            }

            var zone = await _context
                .Cities.Where(c => c.Name.ToLower() == cityName.ToLower())
                .Select(c => c.Zone)
                .FirstOrDefaultAsync();

            return zone;
        }

        public async Task<ZoneRate?> GetRateByZonesAsync(int fromZoneId, int toZoneId)
        {
            return await _context.ZoneRates.FirstOrDefaultAsync(r =>
                r.FromZoneId == fromZoneId && r.ToZoneId == toZoneId
            );
        }
    }
}
