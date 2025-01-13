using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository
{
    public interface IShipmentMethodRepository : IRepository<ShipmentMethod>
    {
        Task<ShipmentMethod?> GetCustomerByNameAsync(string name);
        Task<ShipmentMethod> GetAsync(Func<ShipmentMethod, bool> predicate);
    }
}
