using System;
using System.Collections.Generic;

namespace MeetingRooms_Backend.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int? CompanyId { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual Company? Company { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
