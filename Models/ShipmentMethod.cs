namespace LogisticsManagementSystem.Models
{
    public class ShipmentMethod
    {
        public int ShipmentMethodID { get; set; }   
        public string Name { get; set; }     // (e.g., Standard, Express)
        public decimal Cost { get; set; }   
        public string? Duration { get; set; }  // Estimated delivery duration (e.g., 3-5 days)
        public ICollection<Shipment>? Shipments { get; set; }
    }
}
