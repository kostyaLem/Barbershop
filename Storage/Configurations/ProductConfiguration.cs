using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Storage.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Cost).IsRequired();

        builder
           .HasOne(p => p.Order)
           .WithMany(o => o.Products)
           .HasForeignKey(k => k.OrderId)
           .OnDelete(DeleteBehavior.NoAction);
    }
}