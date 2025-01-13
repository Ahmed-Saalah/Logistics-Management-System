namespace LogisticsManagementSystem.Models
{
    public class ShipmentMethod
    {
        public int ShipmentMethodID { get; set; }   
        public string Name { get; set; }   
        public decimal Cost { get; set; }   
        public string? Duration { get; set; }  
        public ICollection<Shipment>? Shipments { get; set; }
    }
}
