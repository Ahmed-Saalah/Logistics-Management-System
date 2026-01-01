using LogisticsManagementSystem.DbContext;
using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Configurations.Seed
{
    public static class ShipmentMethodSeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.ShipmentMethods.Any())
            {
                return;
            }

            var methods = new List<ShipmentMethod>
            {
                new ShipmentMethod
                {
                    Name = "Standard Shipping",
                    Cost = 15.00m,
                    Duration = "5-7 Business Days",
                },
                new ShipmentMethod
                {
                    Name = "Express Shipping",
                    Cost = 23.50m,
                    Duration = "2-3 Business Days",
                },
            };

            await context.ShipmentMethods.AddRangeAsync(methods);
            await context.SaveChangesAsync();
        }
    }
}
