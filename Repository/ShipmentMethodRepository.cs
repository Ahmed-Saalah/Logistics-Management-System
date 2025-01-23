using LogisticsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Repository
{
    public class ShipmentMethodRepository : Repository<ShipmentMethod>, IShipmentMethodRepository
    {
        public ShipmentMethodRepository(LogisticsManagementContext context) : base(context)
        {
        }

        public async Task<ShipmentMethod?> GetShipmentMethodByNameAsync(string name)
        {
            return await _context.ShipmentMethods.FirstOrDefaultAsync(m => m.Name == name);
        }
        public async Task<ShipmentMethod> GetAsync(Func<ShipmentMethod, bool> predicate)
        {
            return await Task.Run(() => _context.ShipmentMethods.FirstOrDefault(predicate));
        }

        public async Task<ShipmentMethod> GetByIdAsync(int id)
        {
            var entity = await _context.Set<ShipmentMethod>().FindAsync(id);
            return entity;
        }
    }
}
