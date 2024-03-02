using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barbershop.DAL.Configurations;

internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admin");
        builder.Property(p => p.FirstName).IsRequired();
        builder.Property(p => p.PasswordHash).IsRequired();
    }
}