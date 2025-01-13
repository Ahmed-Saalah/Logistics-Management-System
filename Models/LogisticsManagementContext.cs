using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Models
{
    public class LogisticsManagementContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentMethod> ShipmentMethods { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public LogisticsManagementContext(DbContextOptions<LogisticsManagementContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LogisticsManagementContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
