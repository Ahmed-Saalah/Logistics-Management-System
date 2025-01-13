﻿using LogisticsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LogisticsManagementContext context) : base(context)
        {
        }

        public async Task<Customer?> GetCustomerByUsernameAsync(string username)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Name == username);
        }

        public async Task<int?> GetCustomerIdByUsernameAsync(string username)
        {
            var customer = await GetCustomerByUsernameAsync(username);
            return customer?.CustomerId;
        }
    }
}
