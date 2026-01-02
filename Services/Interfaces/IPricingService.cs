using Logex.API.Models;

namespace Logex.API.Services.Interfaces
{
    public interface IPricingService
    {
        decimal CalculateShipmentTotal(Shipment shipment);
    }
}
