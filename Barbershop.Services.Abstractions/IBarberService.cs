using Barbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbershop.Services.Abstractions;

public interface IBarberService
{
    public Task AddBarber(Barber barber);

    public Task<Barber> GetBarber(int id);

    public Task<IReadOnlyList<Barber>> GetAllBarbers();

    public Task<IReadOnlyList<Order>> GetBarbersWorkSchedule(int barberId, DateTime? startPeriod, DateTime? endPeriod, bool doneOnly = false);

    public Task UpdateBarber(Barber barber);

    public Task UpdateBarbersPassword(int barberId, string password);

    public Task DeleteBarber(int id);
}