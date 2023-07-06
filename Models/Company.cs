using System;
using System.Collections.Generic;

namespace MeetingRooms_Backend.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Email { get; set; } = null!;

    public string? Logo { get; set; }

    public bool Active { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
