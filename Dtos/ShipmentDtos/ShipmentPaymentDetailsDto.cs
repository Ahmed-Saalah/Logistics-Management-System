using Logex.API.Models;

namespace Logex.API.Dtos.ShipmentDtos
{
    public class ShipmentPaymentDetailsDto
    {
        public Shipment Shipment { get; set; }
        public string? PaymentClientSecret { get; set; }
    }
}
