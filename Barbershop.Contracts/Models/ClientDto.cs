﻿namespace Barbershop.Contracts.Models;

public class ClientDto : UserDto
{
    public string Notes { get; set; }

    public virtual ICollection<OrderDto> Orders { get; set; }
}