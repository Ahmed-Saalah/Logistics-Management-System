namespace LogisticsManagementSystem.Models
{
    public class Payment
    {
        public int PaymentId {  get; set; }
        public DateTime? PaymentDate {  get; set; }
        public decimal Amount { get; set; }
        public string? CardNumber { get; set; }
        public string? CVC { get; set; }
        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
        public int? ShipemntId { get; set; }
        public Shipment? Shipment { get; set; }
    }
}
