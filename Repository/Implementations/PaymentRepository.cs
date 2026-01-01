using LogisticsManagementSystem.DbContext;
using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository.Interfaces;

namespace LogisticsManagementSystem.Repository.Implementations
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context)
            : base(context) { }
    }
}
