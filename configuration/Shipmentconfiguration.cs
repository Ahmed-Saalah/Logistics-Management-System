using LogisticsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.configuration
{
    public class Shipmentconfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.ShipmentId);

            builder.Property(s => s.ShipperName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.ShipperEmail)
               .IsRequired()
               .HasMaxLength(50); 

            builder.Property(s => s.ShipperPhone)
                .HasMaxLength(15); 

            builder.Property(s => s.ShipperCountry)
                .HasMaxLength(20); 

            builder.Property(s => s.ShipperCity)
                .HasMaxLength(20); 

            builder.Property(s => s.ShipperStreet)
                .HasMaxLength(20); 

            builder.Property(s => s.ReceiverName)
                .IsRequired()
                .HasMaxLength(20); 

            builder.Property(s => s.ReceiverEmail)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(s => s.ReceiverPhone)
                .HasMaxLength(15);

            builder.Property(s => s.ReceiverCountry)
                .HasMaxLength(20);

            builder.Property(s => s.ReceiverCity)
                .HasMaxLength(20); 

            builder.Property(s => s.ReceiverStreet)
                .HasMaxLength(20);

            builder.HasOne(s => s.Customer)
               .WithMany(c => c.Shipments)
               .HasForeignKey(s => s.CustomerId) 
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ShipmentMethod)
                .WithMany(sm => sm.Shipments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Payment)
                .WithOne(p => p.Shipment)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
