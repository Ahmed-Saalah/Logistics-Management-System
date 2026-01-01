using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository.Interfaces
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        Task<Shipment> GetShipmentByTrackingNumberAsync(string trackingNumber);
    }
}
