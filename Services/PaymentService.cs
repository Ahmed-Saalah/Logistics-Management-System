using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository;

namespace LogisticsManagementSystem.Services
{
    public class PaymentService
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

            payment.PaymentDate = DateTime.UtcNow;

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

        public async Task UpdatePaymentAsync(int paymentId, Payment updatedPayment)
        {
            var existingPayment = await _paymentRepository.GetByIdAsync(paymentId);
            
            if (existingPayment == null)
            {
                throw new ArgumentException($"Payment with ID {paymentId} not found.");
            }

            existingPayment.Amount = updatedPayment.Amount;
            existingPayment.PaymentDate = updatedPayment.PaymentDate;
            existingPayment.ShipemntId = updatedPayment.ShipemntId;
            existingPayment.PaymentMethodId = updatedPayment.PaymentMethodId;

            await _paymentRepository.UpdateAsync(existingPayment);
        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            
            if (payment == null)
            {
                throw new ArgumentException($"Payment with ID {paymentId} not found.");
            }

            await _paymentRepository.DeleteAsync(paymentId);
        }
    }
}
