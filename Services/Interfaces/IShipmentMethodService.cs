using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Services.Interfaces
{
    public interface IShipmentMethodService
    {
        Task<ShipmentMethod> GetByIdAsync(int id);

        Task<decimal> GetShipmentMethodCostAsync(int id);

        Task<ShipmentMethod> GetDefultShipmentMethod();
    }
}
