using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.DTO.ShipmentDTOs
{
    public class ShipmentDTO
    {
        public int ShipmentId { get; set; }
        public string ShipperName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ShipmentStatus Status { get; set; }
    }
}
