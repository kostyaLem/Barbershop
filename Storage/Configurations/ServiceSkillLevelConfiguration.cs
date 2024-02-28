using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Storage.Configurations;

internal class ServiceSkillLevelConfiguration : IEntityTypeConfiguration<ServiceSkillLevel>
{
    public void Configure(EntityTypeBuilder<ServiceSkillLevel> builder)
    {
        builder.ToTable("ServiceSkillLevel");
        builder.Property(p => p.Cost).IsRequired();
        builder.Property(p => p.MinutesDuration).IsRequired();
        builder.Property(p => p.ServiceId).IsRequired();

        builder
           .HasOne(s => s.Order)
           .WithMany(o => o.ServiceSkillLevels)
           .HasForeignKey(k => k.OrderId)
           .OnDelete(DeleteBehavior.Cascade);

        builder
         .HasOne(s => s.Service)
         .WithMany(o => o.ServiceSkillLevels)
         .HasForeignKey(k => k.ServiceId)
         .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.SkillLevel).HasConversion(new EnumToStringConverter<SkillLevel>());
    }
}