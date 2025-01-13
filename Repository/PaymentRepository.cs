using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(LogisticsManagementContext context) : base(context)
        {
        }
    }
}
