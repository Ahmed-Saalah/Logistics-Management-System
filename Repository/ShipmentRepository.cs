using LogisticsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Repository
{
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(LogisticsManagementContext context) : base(context)
        {
        }

        private string GenerateTrackingNumber()
        {
            var prefix = "TRK"; // Optional: Customize the prefix for tracking numbers
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss"); // Timestamp for uniqueness
            var randomSuffix = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(); // 8-character random string
            return $"{prefix}-{timestamp}-{randomSuffix}";
        }

        // Override the Add method to generate a tracking number when a shipment is added
        public new async Task AddAsync(Shipment shipment)
        {
            // Generate and assign the tracking number
            shipment.TrackingNumber = GenerateTrackingNumber();
            shipment.CreatedAt = DateTime.UtcNow;

            await base.AddAsync(shipment);
        }

        public async Task<Shipment> GetShipmentByTrackingNumberAsync(string trackingNumber)
        {
            return await _context.Set<Shipment>().FirstOrDefaultAsync(s => s.TrackingNumber == trackingNumber);
        }
    }
}
