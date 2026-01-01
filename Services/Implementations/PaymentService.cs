using LogisticsManagementSystem.DTOs.Responses;
using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository.Interfaces;
using LogisticsManagementSystem.Services.Interfaces;

namespace LogisticsManagementSystem.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentException("Payment cannot be null.");
            }

            payment.CreatedAt = DateTime.UtcNow;

            await _paymentRepository.AddAsync(payment);
            return payment;
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null)
            {
                throw new ArgumentException($"Payment with ID {paymentId} not found.");
            }
            return payment;
        }

        public async Task<ServiceResponse> UpdatePaymentAsync(int paymentId, Payment updatedPayment)
        {
            var existingPayment = await _paymentRepository.GetByIdAsync(paymentId);

            if (existingPayment == null)
            {
                return new ServiceResponse(false, "payment not found");
            }

            existingPayment.Amount = updatedPayment.Amount;
            existingPayment.CreatedAt = updatedPayment.CreatedAt;
            existingPayment.ShipemntId = updatedPayment.ShipemntId;

            await _paymentRepository.UpdateAsync(existingPayment);
            return new ServiceResponse(true, "payment updated successfully");
        }

        public async Task<ServiceResponse> DeletePaymentAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);

            if (payment == null)
            {
                return new ServiceResponse(false, $"Payment with ID {paymentId} not found.");
            }

            await _paymentRepository.DeleteAsync(paymentId);
            return new ServiceResponse(true, "payment deleted successfully");
        }
    }
}
