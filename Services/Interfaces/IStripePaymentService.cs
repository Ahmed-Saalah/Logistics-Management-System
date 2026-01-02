using LogisticsManagementSystem.Models;
using Stripe;

namespace LogisticsManagementSystem.Services.Interfaces
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
