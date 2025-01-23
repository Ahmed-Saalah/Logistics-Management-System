using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.DTO.ShipmentDTOs
{
    public class ShipmentWithRateDTO
    {
        public int Quantity { get; set; }
        public int Weight { get; set; }

        public string ShipperCountry { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperStreet { get; set; }

        public string ReceiverCountry { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverStreet { get; set; }

        public int ShipmentMethodId { get; set ; }

    }
}
