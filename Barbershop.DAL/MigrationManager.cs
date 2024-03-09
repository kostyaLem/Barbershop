using Barbershop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.DAL;

public static class MigrationManager
{
    public static async Task Migrate(this IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<BarbershopContextFactory>()
            .CreateContext();

        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

        if (pendingMigrations.Any())
        {
            context.Database.Migrate();

            await context.Admins.AddAsync(new Domain.Models.Admin()
            {
                User = new()
                {
                    FirstName = "Администратор",
                    PhoneNumber = "89211234567"
                },
                Login = "admin",
                PasswordHash = "x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37A=="
            });

            await context.SaveChangesAsync();
        }
    }
}