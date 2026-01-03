using Logex.API.Models;

namespace Logex.API.Services.Interfaces
{
    public interface IPricingService
    {
        Task<decimal> CalculateShipmentTotalAsync(Shipment shipment);
    }
}
