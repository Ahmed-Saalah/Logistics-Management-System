using LogisticsManagementSystem.DTOs.ShipmentDTOs;
using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<Shipment> CreateShipmentAsync(CreateShipmentDto shipmentCreateDTO, int customerId);

        Task<Shipment> GetByIdAsync(int id);

        Task<Shipment> GetByTrackingNumber(string trackingNumber);

        Task UpdateShipmentAsync(int id, UpdateShipmentDto shipment);

        Task DeleteAsync(int id);

        Task Update(Shipment shipment);

        Task<decimal> GetTotalCost(int quantity, decimal weight, decimal shipmentMethodCost);
    }
}
