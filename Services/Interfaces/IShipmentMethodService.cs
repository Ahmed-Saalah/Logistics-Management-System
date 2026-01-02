using Logex.API.Models;

namespace Logex.API.Services.Interfaces
{
    public interface IShipmentMethodService
    {
        Task<ShipmentMethod> GetByIdAsync(int id);

        Task<decimal> GetShipmentMethodCostAsync(int id);

        Task<ShipmentMethod> GetDefaultShipmentMethodAsync();
    }
}
