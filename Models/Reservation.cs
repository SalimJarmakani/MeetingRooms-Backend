using System;
using System.Collections.Generic;

namespace MeetingRooms_Backend.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateTime MeetingDate { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int RoomId { get; set; }

    public int NumberOfAttendees { get; set; }

    public bool MeetingStatus { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
