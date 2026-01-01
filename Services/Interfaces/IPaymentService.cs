using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Services.Interfaces
{
    /// <summary>
    /// Interface for payment-related operations.
    /// </summary>
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(Payment payment);

        Task<Payment> GetPaymentByIdAsync(int paymentId);

        Task UpdatePaymentAsync(int paymentId, Payment updatedPayment);

        Task DeletePaymentAsync(int paymentId);
    }
}
