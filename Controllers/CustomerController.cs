using LogisticsManagementSystem.DTOs.CustomerDTOs;
using LogisticsManagementSystem.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(id);

                if (customer == null)
                    return NotFound(new { Message = "Customer not found." });

                var customerDto = new CustomerDto
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Country = customer.Country,
                    City = customer.City,
                };

                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while processing the request.",
                        Error = ex.Message,
                    }
                );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerDto customerCreateDto)
        {
            if (customerCreateDto == null)
                return BadRequest(new { Message = "Customer data cannot be null." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var customerDto = await _customerService.AddAsync(customerCreateDto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = customerDto.CustomerId },
                    customerDto
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while saving the customer.",
                        Error = ex.Message,
                    }
                );
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerDto data)
        {
            if (data == null)
                return BadRequest(new { Message = "Customer data cannot be null." });

            //if (id != customerUpdateDto.CustomerId)
            //    return BadRequest(new { Message = "Customer ID in the URL does not match the customer ID in the request body." });

            try
            {
                await _customerService.UpdateCustomerAsync(id, data);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while updating the customer.",
                        Error = ex.Message,
                    }
                );
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _customerService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while deleting the customer.",
                        Error = ex.Message,
                    }
                );
            }
        }
    }
}
