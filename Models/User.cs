using Microsoft.AspNetCore.Identity;

namespace Logex.API.Models
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public string? ProfileImageUrl { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }

        public List<Shipment>? Shipments { get; set; }
    }
}
