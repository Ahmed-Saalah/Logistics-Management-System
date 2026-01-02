using Logex.API.Models;
using Stripe;

namespace Logex.API.Services.Interfaces
{
    public interface IStripePaymentService
    {
        // returns a session object or URL directly
        Task<string> CreateCheckoutSessionAsync(
            Payment payment,
            Shipment shipment,
            string originUrl
        );
    }
}
