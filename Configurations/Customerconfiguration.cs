using LogisticsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Configurations
{
    public class Customerconfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Password).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Phone).HasMaxLength(15);

            builder.Property(c => c.Country).HasMaxLength(20);

            builder.Property(c => c.City).HasMaxLength(20);

            builder
                .HasMany(c => c.Shipments)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
