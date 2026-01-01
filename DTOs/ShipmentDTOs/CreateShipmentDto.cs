using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.DTOs.ShipmentDTOs
{
    public class CreateShipmentDto
    {
        #region Ship & Receiver Information
        public string ShipperName { get; set; }
        public string ShipperEmail { get; set; }
        public string ShipperPhone { get; set; }
        public string ShipperCountry { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperStreet { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverStreet { get; set; }
        #endregion

        #region Shipment Details
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public string? Description { get; set; }
        public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
        public int? ShipmentMethodId { get; set; }
        #endregion

        #region Payment Details
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        #endregion
    }

    public enum PaymentStatus
    {
        Pending = 1,
        Completed = 2,
        Failed = 3,
    }
}
