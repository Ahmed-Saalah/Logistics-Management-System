using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.DTOs.ShipmentDTOs
{
    public class ShipmentWithPaymentDTO
    {
        public Shipment Shipment { get; set; }
        public string? PaymentClientSecret { get; set; }
    }
}
