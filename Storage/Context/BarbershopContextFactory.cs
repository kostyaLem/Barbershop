using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Storage.Context;

internal class BarbershopContextFactory : IDesignTimeDbContextFactory<BarbershopContext>
{
    public string ConnectionString { get; } = "Host=localhost;Port=5432;Database=Barbershop;Username=postgres;Password=0707";

    public BarbershopContext CreateDbContext() => CreateDbContext(Array.Empty<string>());

    public BarbershopContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BarbershopContext>();

        optionsBuilder.UseNpgsql(ConnectionString);

        return new BarbershopContext(optionsBuilder.Options);
    }
}