using LogisticsManagementSystem.Services.Interfaces;
using Stripe;

namespace LogisticsManagementSystem.Services.Implementations
{
    public class StripePaymentService : IStripePaymentService
    {
        public async Task<PaymentIntent> CreatePaymentIntent(
            decimal amount,
            string currency = "usd"
        )
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" },
            };

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }

        public async Task<PaymentIntent> ConfirmPayment(string paymentIntentId)
        {
            var service = new PaymentIntentService();
            return await service.ConfirmAsync(paymentIntentId);
        }
    }
}
