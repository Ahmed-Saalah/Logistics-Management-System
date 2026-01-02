using Logex.API.Models;
using Logex.API.Services.Interfaces;
using Logex.API.Settings;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Logex.API.Services.Implementations
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly StripeOptions _stripeOptions;

        public StripePaymentService(IOptions<StripeOptions> stripeOptions)
        {
            _stripeOptions = stripeOptions.Value;
            StripeConfiguration.ApiKey = _stripeOptions.SecretKey;
        }

        public async Task<string> CreateCheckoutSessionAsync(
            Payment payment,
            Shipment shipment,
            string originUrl
        )
        {
            var options = new SessionCreateOptions
            {
                Mode = "payment",
                ClientReferenceId = shipment.ShipmentId.ToString(),
                // Use the passed origin to build dynamic URLs
                SuccessUrl = $"{originUrl}/confirmation.html",
                CancelUrl = $"{originUrl}/index.html",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"Shipment #{shipment.ShipmentId}",
                                Description = shipment.ShipmentMethod?.Name ?? "Logistics Service",
                            },
                            UnitAmount = (long)(payment.Amount * 100),
                        },
                        Quantity = 1,
                    },
                },
                Metadata = new Dictionary<string, string>
                {
                    { "PaymentId", payment.PaymentId.ToString() },
                    { "ShipmentId", shipment.ShipmentId.ToString() },
                },
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return session.Url;
        }
    }
}
