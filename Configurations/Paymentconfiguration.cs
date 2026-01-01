using LogisticsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.configurations
{
    public class Paymentconfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.PaymentId);

            builder.Property(p => p.Amount).IsRequired().HasPrecision(18, 2);

            builder
                .HasOne(p => p.Shipment)
                .WithOne(s => s.Payment)
                .HasForeignKey<Shipment>(s => s.PaymentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserrId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
