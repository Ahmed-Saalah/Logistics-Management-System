using LogisticsManagementSystem.DbContext;
using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context)
            : base(context) { }
    }
}
