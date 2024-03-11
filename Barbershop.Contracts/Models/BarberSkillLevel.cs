using System.ComponentModel;

namespace Barbershop.Contracts.Models;

public enum BarberSkillLevel
{
    [Description("Начинающий")]
    Junior,

    [Description("Средний")]
    Middle,

    [Description("Старший")]
    Senior
}