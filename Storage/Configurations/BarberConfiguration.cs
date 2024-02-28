using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Storage.Configurations;

internal class BarberConfiguration : IEntityTypeConfiguration<Barber>
{
    public void Configure(EntityTypeBuilder<Barber> builder)
    {
        builder.ToTable("Barber");
        builder.Property(p => p.FirstName).IsRequired();
        builder.Property(e => e.SkillLevel).HasConversion(new EnumToStringConverter<SkillLevel>());
    }
}