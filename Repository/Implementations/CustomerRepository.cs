using LogisticsManagementSystem.DbContext;
using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Repository.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context)
            : base(context) { }

        public async Task<Customer?> GetCustomerByUsernameAsync(string username)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Name == username);
        }

        public async Task<int?> GetCustomerIdByUsernameAsync(string username)
        {
            var customer = await GetCustomerByUsernameAsync(username);
            return customer?.CustomerId;
        }
    }
}
