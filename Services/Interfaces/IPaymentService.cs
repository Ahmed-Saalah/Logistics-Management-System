using Logex.API.Common;
using Logex.API.Models;

namespace Logex.API.Services.Interfaces
{
    /// <summary>
    /// Interface for payment-related operations.
    /// </summary>
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(Payment payment);

        Task<Payment> GetPaymentByIdAsync(int paymentId);

        Task<ServiceResponse> UpdatePaymentAsync(int paymentId, Payment updatedPayment);

        Task<ServiceResponse> DeletePaymentAsync(int paymentId);
    }
}
