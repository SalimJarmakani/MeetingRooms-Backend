using System;
using System.Collections.Generic;

namespace MeetingRooms_Backend.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public int Capacity { get; set; }

    public string? Description { get; set; }

    public int CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
