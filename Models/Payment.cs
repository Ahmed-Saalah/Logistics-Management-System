namespace LogisticsManagementSystem.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string? CardNumber { get; set; }
        public string? CVC { get; set; }
        public int? ShipemntId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Shipment? Shipment { get; set; }
        public Customer Customer { get; set; }
    }
}
