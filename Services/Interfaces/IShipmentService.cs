using LogisticsManagementSystem.DTOs;
using LogisticsManagementSystem.DTOs.ShipmentDTOs;
using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<Shipment> CreateShipmentAsync(CreateShipmentDto shipmentCreateDTO, int customerId);

        Task<Shipment> GetByIdAsync(int id);

        Task<Shipment> GetByTrackingNumber(string trackingNumber);

        Task<ServiceResponse> UpdateShipmentAsync(int id, UpdateShipmentDto shipment);

        Task<ServiceResponse> DeleteAsync(int id);

        Task<ServiceResponse> Update(Shipment shipment);

        decimal GetTotalCost(int quantity, decimal weight, decimal shipmentMethodCost);
    }
}
