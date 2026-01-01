using LogisticsManagementSystem.Constants;

namespace LogisticsManagementSystem.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }

        #region shipper and receiver
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

        #region Shipment details
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } = ShipmentStatus.Pending;
        public string TrackingNumber { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        #endregion

        public int UserId { get; set; }
        public int? PaymentId { get; set; }
        public User? User { get; set; }
        public ShipmentMethod? ShipmentMethod { get; set; }
        public Payment? Payment { get; set; }
    }
}
