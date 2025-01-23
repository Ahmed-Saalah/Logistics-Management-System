﻿using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository;

namespace LogisticsManagementSystem.Services
{
    public class ShipmentMethodService
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
            var ShipmentMethod = await _shipmentMethodRepository.GetByIdAsync(id);

            if (ShipmentMethod == null)
            {
                ShipmentMethod = await GetDefultShipmentMethod();
            }
            
            return ShipmentMethod.Cost;
        }

        public async Task<ShipmentMethod> GetDefultShipmentMethod()
        {
            return await _shipmentMethodRepository.GetByIdAsync(1);
        }

    }
}
