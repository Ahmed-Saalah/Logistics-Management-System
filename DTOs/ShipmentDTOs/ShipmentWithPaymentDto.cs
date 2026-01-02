using Logex.API.Models;

namespace Logex.API.DTOs.ShipmentDTOs
{
    public class ShipmentWithPaymentDTO
    {
        public Shipment Shipment { get; set; }
        public string? PaymentClientSecret { get; set; }
    }
}
