using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Services.Interfaces
{
    public interface IPricingService
    {
        decimal CalculateShipmentTotal(Shipment shipment);
    }
}
