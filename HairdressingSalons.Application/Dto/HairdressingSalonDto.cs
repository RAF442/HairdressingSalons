﻿namespace HairdressingSalons.Application.Dto;

public class HairdressingSalonDto
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }

    public string? EncodedName { get; set; }
    public bool IsEditable { get; set; }
}