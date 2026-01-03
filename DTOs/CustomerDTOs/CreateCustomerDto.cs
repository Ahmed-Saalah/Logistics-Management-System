using System.ComponentModel.DataAnnotations;

namespace Logex.API.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }
    }
}
