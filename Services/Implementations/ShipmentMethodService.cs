using Logex.API.Models;
using Logex.API.Repository.Interfaces;
using Logex.API.Services.Interfaces;

namespace Logex.API.Services.Implementations
{
    public class ShipmentMethodService : IShipmentMethodService
    {
        private readonly IShipmentMethodRepository _shipmentMethodRepository;

        public ShipmentMethodService(IShipmentMethodRepository shipmentMethodRepository)
        {
            _shipmentMethodRepository = shipmentMethodRepository;
        }

        public async Task<ShipmentMethod> GetByIdAsync(int id)
        {
            return await _shipmentMethodRepository.GetByIdAsync(id);
        }

        public async Task<decimal> GetShipmentMethodCostAsync(int id)
        {
            var shipmentMethod = await _shipmentMethodRepository.GetByIdAsync(id);

            if (shipmentMethod == null)
            {
                shipmentMethod = await GetDefaultShipmentMethodAsync();
            }

            if (shipmentMethod == null)
                throw new Exception("Default shipment method not found in database.");

            return shipmentMethod.Cost;
        }

        public async Task<ShipmentMethod> GetDefaultShipmentMethodAsync()
        {
            return await _shipmentMethodRepository.GetByIdAsync(1);
        }
    }
}
