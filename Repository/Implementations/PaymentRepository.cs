using Logex.API.DbContext;
using Logex.API.Models;
using Logex.API.Repository.Interfaces;

namespace Logex.API.Repository.Implementations
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context)
            : base(context) { }
    }
}
