using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository.Interfaces
{
    public interface IShipmentMethodRepository : IRepository<ShipmentMethod>
    {
        Task<ShipmentMethod?> GetShipmentMethodByNameAsync(string name);
        Task<ShipmentMethod> GetAsync(Func<ShipmentMethod, bool> predicate);
    }
}
