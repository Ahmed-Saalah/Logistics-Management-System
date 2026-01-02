using System.ComponentModel.DataAnnotations;

namespace Logex.API.DTOs.CustomerDTOs
{
    public class UpdateCustomerDto
    {
        public int? CustomerId { get; set; }

        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(50, MinimumLength = 6)]
        public string? Password { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }
    }
}
