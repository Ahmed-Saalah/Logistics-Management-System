using LogisticsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.configuration
{
    public class Paymentconfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.PaymentId);

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.HasOne(p => p.Shipment)
            .WithOne(s => s.Payment)
            .HasForeignKey<Shipment>(s => s.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
