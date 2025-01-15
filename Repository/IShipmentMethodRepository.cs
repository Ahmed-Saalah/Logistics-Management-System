using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository
{
    public interface IShipmentMethodRepository : IRepository<ShipmentMethod>
    {
        Task<ShipmentMethod?> GetShipmentMethodByNameAsync(string name);
        Task<ShipmentMethod> GetAsync(Func<ShipmentMethod, bool> predicate);
    }
}
