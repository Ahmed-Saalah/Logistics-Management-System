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
        public ShipmentStatus Status { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        #endregion

        public int CustomerId { get; set; }
        public int? PaymentId { get; set; }
        public Customer? Customer { get; set; }
        public ShipmentMethod? ShipmentMethod { get; set; } 
        public Payment? Payment { get; set; }

    }
    public enum ShipmentStatus
    {
        Pending = 1,
        Shipped = 2,
        InTransit = 3,
        Delivered = 4,
        Cancelled = 5
    }
}


