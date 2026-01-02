using Logex.API.Models;
using Logex.API.Services.Interfaces;

namespace Logex.API.Services.Implementations
{
    public class PricingService : IPricingService
    {
        public decimal CalculateShipmentTotal(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException(nameof(shipment));
            }

            if (shipment.ShipmentMethod == null)
            {
                throw new InvalidOperationException(
                    "ShipmentMethod is required for price calculation."
                );
            }

            decimal total = (shipment.Quantity * shipment.Weight) + shipment.ShipmentMethod.Cost;

            return total;
        }
    }
}
