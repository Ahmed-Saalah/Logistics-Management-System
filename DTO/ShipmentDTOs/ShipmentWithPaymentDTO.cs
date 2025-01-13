using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.DTO.ShipmentDTOs
{
    public class ShipmentWithPaymentDTO
    {
        public Shipment Shipment { get; set; }
        public string? PaymentClientSecret { get; set; }
    }
}
