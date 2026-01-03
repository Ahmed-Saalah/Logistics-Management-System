using Logex.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Logex.API.Data.Seeding
{
    public static class ShipmentMethodSeeder
    {
        public static void SeedShipmentMethodsData(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ShipmentMethod>()
                .HasData(
                    new ShipmentMethod
                    {
                        Id = 1,
                        Name = "Standard Shipping",
                        Cost = 15.00m,
                        Duration = "5-7 Business Days",
                    },
                    new ShipmentMethod
                    {
                        Id = 2,
                        Name = "Express Shipping",
                        Cost = 23.50m,
                        Duration = "2-3 Business Days",
                    }
                );
        }
    }
}
