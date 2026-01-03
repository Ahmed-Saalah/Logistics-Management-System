namespace Logex.API.Dtos.ShipmentDtos
{
    public class UpdateShipmentDto
    {
        public string ShipperCountry { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperStreet { get; set; }
        public string ShipperPhone { get; set; }

        public string ReceiverCountry { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverStreet { get; set; }
        public string ReceiverPhone { get; set; }
    }
}
