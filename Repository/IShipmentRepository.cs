using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        Task<Shipment> GetShipmentByTrackingNumberAsync(string trackingNumber);

    }
}
