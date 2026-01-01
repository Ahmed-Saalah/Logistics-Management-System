using LogisticsManagementSystem.DTOs.CustomerDTOs;
using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository;

namespace LogisticsManagementSystem.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<CustomerDto> AddAsync(CreateCustomerDto customerCreateDto)
        {
            var customer = new Customer
            {
                Name = customerCreateDto.Name,
                Email = customerCreateDto.Email,
                Password = customerCreateDto.Password,
                Phone = customerCreateDto.Phone,
                Country = customerCreateDto.Country,
                City = customerCreateDto.City,
            };

            await _customerRepository.AddAsync(customer);

            var customerDto = new CustomerDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Country = customer.Country,
                City = customer.City,
            };

            return customerDto;
        }

        public async Task UpdateCustomerAsync(int id, UpdateCustomerDto customerUpdateDto)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);

            if (existingCustomer == null)
                throw new ArgumentException($"Customer with ID {id} not found.");

            existingCustomer.Name = customerUpdateDto.Name ?? existingCustomer.Name;
            existingCustomer.Email = customerUpdateDto.Email ?? existingCustomer.Email;
            existingCustomer.Password = customerUpdateDto.Password ?? existingCustomer.Password;
            existingCustomer.Phone = customerUpdateDto.Phone ?? existingCustomer.Phone;
            existingCustomer.Country = customerUpdateDto.Country ?? existingCustomer.Country;
            existingCustomer.City = customerUpdateDto.City ?? existingCustomer.City;

            await _customerRepository.UpdateAsync(existingCustomer);
        }

        public async Task DeleteAsync(int id)
        {
            var shipment = await _customerRepository.GetByIdAsync(id);
            if (shipment != null)
            {
                await _customerRepository.DeleteAsync(id);
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
        }

        public async Task<int?> GetCustomerIdByUsernameAsync(string username)
        {
            return await _customerRepository.GetCustomerIdByUsernameAsync(username);
            ;
        }
    }
}
