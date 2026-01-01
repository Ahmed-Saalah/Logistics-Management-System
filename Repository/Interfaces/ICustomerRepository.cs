using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> GetCustomerByUsernameAsync(string username);
        Task<int?> GetCustomerIdByUsernameAsync(string username);
    }
}
