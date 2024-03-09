using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbershop.Contracts.Commands;

public class UpsertServiceCommand
{
    public string Name { get; set; }
}