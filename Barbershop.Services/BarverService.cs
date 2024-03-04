using Barbershop.Domain.Models;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class BarverService : IBarberService
{
    public Task AddBarber(Barber barber)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBarber(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Barber>> GetAllBarbers()
    {
        throw new NotImplementedException();
    }

    public Task<Barber> GetBarber(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetBarbersWorkSchedule(int barberId, DateTime? startPeriod, DateTime? endPeriod, bool doneOnly = false)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBarber(Barber barber)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBarbersPassword(int barberId, string password)
    {
        throw new NotImplementedException();
    }
}