namespace LogisticsManagementSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name {  get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Country{ get; set; }
        public string? City { get; set; }

        public List<Shipment>? Shipments { get; set; }
    }
}
