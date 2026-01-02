using Logex.API.Models;

namespace Logex.API.Repository.Interfaces
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        Task<Shipment> GetShipmentByTrackingNumberAsync(string trackingNumber);
    }
}
