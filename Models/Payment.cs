namespace LogisticsManagementSystem.Models
{
    public class Payment
    {
        public int PaymentId {  get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate {  get; set; }
        public int ShipemntId {  get; set; }
        public Shipment? Shipment { get; set; }
        public int? PaymentMethodId { get; set; }
        public string CardNumber { get; set; }
        public string CVC {  get; set; }
        public int ExpirationMonth { get; set; } // Card expiration month (1-12)
        public int ExpirationYear { get; set; } // Card expiration year (4-digit format)
    }
}
