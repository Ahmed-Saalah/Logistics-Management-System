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
            var prefix = "TRK"; 
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss"); 
            var randomSuffix = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            return $"{prefix}-{timestamp}-{randomSuffix}";
        }

        public new async Task<Shipment> AddAsync(Shipment shipment)
        {
            shipment.TrackingNumber = GenerateTrackingNumber();
            shipment.CreatedAt = DateTime.UtcNow;

            await base.AddAsync(shipment);
            return shipment;
        }

        public new async Task<Shipment> GetByIdAsync(int id)
        {
            var entity = await _context.Shipments
                .Include(s => s.ShipmentMethod)
                .FirstOrDefaultAsync(s => s.ShipmentId == id);

            

            return entity;
        }

        public async Task<Shipment> GetShipmentByTrackingNumberAsync(string trackingNumber)
        {
            return await _context.Set<Shipment>().FirstOrDefaultAsync(s => s.TrackingNumber == trackingNumber);
        }
    }
}
