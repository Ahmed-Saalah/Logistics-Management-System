using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.DTOs.ShipmentDTOs
{
    public class ShipmentDTO
    {
        public int ShipmentId { get; set; }
        public string ShipperName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
