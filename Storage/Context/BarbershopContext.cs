using Barbershop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Context;

public class BarbershopContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceSkillLevel> ServiceSkillLevels { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Barber> Barbers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<BarbershopParameterRow> BarbershopParameterRows { get; set; }



    public BarbershopContext(DbContextOptions<BarbershopContext> options) : base(options)
    {
      this.Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }
}