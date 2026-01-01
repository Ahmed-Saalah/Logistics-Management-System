using Stripe;

namespace LogisticsManagementSystem.Services.Interfaces
{
    /// <summary>
    /// Interface for Stripe payment processing service.
    /// </summary>
    public interface IStripePaymentService
    {
        Task<PaymentIntent> CreatePaymentIntent(decimal amount, string currency);

        Task<PaymentIntent> ConfirmPayment(string paymentIntentId);
    }
}
