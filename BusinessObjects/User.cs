using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class User
{
    public int UserId { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Cccd { get; set; } = null!;

    public string? Role { get; set; }

    public DateOnly? DateJoined { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
