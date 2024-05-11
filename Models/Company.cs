using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();


    [JsonIgnore]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
